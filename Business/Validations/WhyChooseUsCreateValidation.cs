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
    public class WhyChooseUsCreateValidation : AbstractValidator<WhyChooseUsCreateDto>
    {
        private readonly ApplicationDbContext _context;
        public WhyChooseUsCreateValidation(ApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.LanguageId)
            .Must(languageId => !_context.WhyChooseUses.Any(a => a.LanguageId == languageId))
            .WithMessage(UiMessages.DublicatLanguageMessage("məlumat"));

            RuleFor(x => x.Header)
              .MinimumLength(3)
              .WithMessage(UiMessages.MinLenghtMessage("Açıqlama", 3))
              .MaximumLength(3000)
              .WithMessage(UiMessages.MaxLenghtMessage("Açıqlama", 3000))
              .NotEmpty()
              .WithMessage(UiMessages.NotEmptyMessage("Açıqlama"));
        }
    }
}
