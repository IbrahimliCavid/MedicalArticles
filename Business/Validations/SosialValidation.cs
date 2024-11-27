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
    public class SosialValidation : AbstractValidator<Sosial>
    {
        public SosialValidation()
        {
            RuleFor(x => x.FacebookUrl)
                .MaximumLength(500)
                .WithMessage(UiMessages.MaxLenghtMessage("Facebook url'si", 500));

            RuleFor(x => x.TwitterUrl)
    .MaximumLength(500)
    .WithMessage(UiMessages.MaxLenghtMessage("Twitter url'si", 500));

            RuleFor(x => x.WhatsappUrl)
    .MaximumLength(500)
    .WithMessage(UiMessages.MaxLenghtMessage("Vatsap url'si", 500));


            RuleFor(x => x.Telegram)
    .MaximumLength(500)
    .WithMessage(UiMessages.MaxLenghtMessage("Teleqram url'si", 500));

            RuleFor(x => x.InstagramUrl)
    .MaximumLength(500)
    .WithMessage(UiMessages.MaxLenghtMessage("İnstaqram url'si", 500));

        }
    }
}
