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
    public class HealthTipCreateValidation : AbstractValidator<HealthTipCreateDto>
    {
        private readonly ApplicationDbContext _context;
        public HealthTipCreateValidation(ApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.LanguageId)
            .Must(languageId => !_context.HealthTips.Any(a => a.LanguageId == languageId))
            .WithMessage(UiMessages.DublicatLanguageMessage("məlumat"));

            RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage(UiMessages.MinLenghtMessage("Ad", 3))
                .MaximumLength(100)
                .WithMessage(UiMessages.MaxLenghtMessage("Ad", 100))
                .NotEmpty()
                .WithMessage(UiMessages.NotEmptyMessage("Ad"));

            RuleFor(x => x.Surname)
               .MinimumLength(3)
               .WithMessage(UiMessages.MinLenghtMessage("Soyad", 3))
               .MaximumLength(100)
               .WithMessage(UiMessages.MaxLenghtMessage("Soyad", 100))
               .NotEmpty()
               .WithMessage(UiMessages.NotEmptyMessage("Soyad"));

            RuleFor(x => x.Header)
               .MinimumLength(3)
               .WithMessage(UiMessages.MinLenghtMessage("Vəzifə", 3))
               .MaximumLength(300)
               .WithMessage(UiMessages.MaxLenghtMessage("Vəzifə", 300))
               .NotEmpty()
               .WithMessage(UiMessages.NotEmptyMessage("Vəzifə"));

            RuleFor(x => x.Title)
                .MinimumLength(3)
                .WithMessage(UiMessages.MinLenghtMessage("Mövzu", 3))
                .MaximumLength(300)
                .WithMessage(UiMessages.MaxLenghtMessage("Mövzu", 300))
                .NotEmpty()
                .WithMessage(UiMessages.NotEmptyMessage("Mövzu"));

            RuleFor(x => x.Description)
                .MinimumLength(3)
                .WithMessage(UiMessages.MinLenghtMessage("Açıqlama", 3))
                .MaximumLength(3000)
                .WithMessage(UiMessages.MaxLenghtMessage("Açıqlama", 3000))
                .NotEmpty()
                .WithMessage(UiMessages.NotEmptyMessage("Açıqlama"));

            RuleFor(x => x.SubTitle)
               .MinimumLength(3)
               .WithMessage(UiMessages.MinLenghtMessage("Alt başlıq", 3))
               .MaximumLength(300)
               .WithMessage(UiMessages.MaxLenghtMessage("Alt başlıq", 300))
               .NotEmpty()
               .WithMessage(UiMessages.NotEmptyMessage("Alt başlıq"));
        }
    }
}
