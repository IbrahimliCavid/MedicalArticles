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
    public class HealthTipItemValidation : AbstractValidator<HealthTipItem>
    {
        public HealthTipItemValidation()
        {
            RuleFor(x => x.Text)
               .MinimumLength(3)
               .WithMessage(UiMessages.MinLenghtMessage("Bu xana", 3))
               .MaximumLength(300)
               .WithMessage(UiMessages.MaxLenghtMessage("Bu xana", 300))
               .NotEmpty()
               .WithMessage(UiMessages.NotEmptyMessage("Bu xana"));
        }
    }
}
