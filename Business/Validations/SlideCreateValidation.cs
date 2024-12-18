using Business.BaseMessages;
using DataAccess.SqlServerDBContext;
using Entities.Dtos;
using Entities.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class SlideCreateValidation : AbstractValidator<SlideCreateDto>
    {
        private readonly ApplicationDbContext _context;
        public SlideCreateValidation(ApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.LanguageId)
            .Must(languageId => !_context.Slides.Any(a => a.LanguageId == languageId))
            .WithMessage(UiMessages.DublicatLanguageMessage("slayd"));

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage(UiMessages.NotEmptyMessage("Başlıq"))
                .MinimumLength(3)
                .WithMessage(UiMessages.MinLenghtMessage("Başlıq", 3))
                .MaximumLength(200)
                .WithMessage(UiMessages.MaxLenghtMessage("Başlıq", 200));

            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage(UiMessages.NotEmptyMessage("Məzmun"))
                .MinimumLength(3)
                .WithMessage(UiMessages.MinLenghtMessage("Məzmun", 3))
                .MaximumLength(2000)
                .WithMessage(UiMessages.MaxLenghtMessage("Məzmun", 2000));
        }
    }
}
