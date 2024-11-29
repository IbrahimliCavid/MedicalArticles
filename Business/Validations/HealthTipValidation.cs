using Business.BaseMessages;
using Entities.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class HealthTipValidation : AbstractValidator<HealthTip>
    {
        public HealthTipValidation()
        {
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
               .WithMessage(UiMessages.MinLenghtMessage("Başlıq", 3))
               .MaximumLength(300)
               .WithMessage(UiMessages.MaxLenghtMessage("Başlıq", 300))
               .NotEmpty()
               .WithMessage(UiMessages.NotEmptyMessage("Başlıq"));

            RuleFor(x => x.Title)
                .MinimumLength(3)
                .WithMessage(UiMessages.MinLenghtMessage("Bu xana", 3))
                .MaximumLength(300)
                .WithMessage(UiMessages.MaxLenghtMessage("Bu xana", 300))
                .NotEmpty()
                .WithMessage(UiMessages.NotEmptyMessage("Bu xana"));

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
