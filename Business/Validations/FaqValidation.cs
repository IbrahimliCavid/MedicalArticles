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
    public class FaqValidation : AbstractValidator<Faq>
    {
        public FaqValidation()
        {
            RuleFor(x => x.Question)
                .NotEmpty()
                .WithMessage(UiMessages.NotEmptyMessage("Sual"))
                .MinimumLength(3)
                .WithMessage(UiMessages.MinLenghtMessage("Sual", 3))
                .MaximumLength(2000)
                .WithMessage(UiMessages.MaxLenghtMessage("Sual", 2000));

            RuleFor(x => x.Answer)
                .NotEmpty()
                .WithMessage(UiMessages.NotEmptyMessage("Cavab"))
                .MinimumLength(3)
                .WithMessage(UiMessages.MinLenghtMessage("Cavab", 3))
                .MaximumLength(3000)
                .WithMessage(UiMessages.MaxLenghtMessage("Cavab", 3000));
        }
    }
}
