using Business.BaseMessages;
using Core.DefaultValues;
using Entities.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class AboutValidation : AbstractValidator<About>
    {
        public AboutValidation()
        {
            RuleFor(x=>x.Title)
                .NotEmpty()
                .WithMessage(UiMessages.NotEmptyMessage("Başlıq"))
                .MaximumLength(300)
                .WithMessage(UiMessages.MaxLenghtMessage("Başlıq", 300))
                .MinimumLength(3)
                .WithMessage(UiMessages.MinLenghtMessage("Baçlıq", 3));

            RuleFor(x => x.Description)
              .NotEmpty()
              .WithMessage(UiMessages.NotEmptyMessage("Açıqlama"))
              .MaximumLength(300)
              .WithMessage(UiMessages.MaxLenghtMessage("Açıqlama", 300))
              .MinimumLength(3)
              .WithMessage(UiMessages.MinLenghtMessage("Açıqlama", 3));

            
        }
    }
}
