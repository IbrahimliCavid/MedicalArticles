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
    public class ServiceAboutItemValidation : AbstractValidator<ServiceAboutItem>
    {
        public ServiceAboutItemValidation() {
            RuleFor(x => x.Text)
                   .MinimumLength(3)
                   .WithMessage(UiMessages.MinLenghtMessage("Mətn", 3))
                   .MaximumLength(300)
                   .WithMessage(UiMessages.MaxLenghtMessage("Mətn", 300))
                   .NotEmpty()
                   .WithMessage(UiMessages.NotEmptyMessage("Mətn"));
        }
    }
}
