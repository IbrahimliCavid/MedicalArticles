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
    public class WhyChooseUsItemValidation : AbstractValidator<WhyChooseUsItem>
    {
        public WhyChooseUsItemValidation() {

            RuleFor(x => x.Title)
                .MinimumLength(3)
                .WithMessage(UiMessages.MinLenghtMessage("Başlıq", 3))
                .MaximumLength(300)
                .WithMessage(UiMessages.MaxLenghtMessage("Başlıq", 300))
                .NotEmpty()
                .WithMessage(UiMessages.NotEmptyMessage("Başlıq"));

            RuleFor(x => x.Description)
                .MinimumLength(3)
                .WithMessage(UiMessages.MinLenghtMessage("Açıqlama", 3))
                .MaximumLength(3000)
                .WithMessage(UiMessages.MaxLenghtMessage("Açıqlama", 3000))
                .NotEmpty()
                .WithMessage(UiMessages.NotEmptyMessage("Açıqlama"));
        }
    }
}
