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
    public class ContactValidation : AbstractValidator<Contact>
    {
        public ContactValidation()
        {
            RuleFor(x=> x.Name)
                .NotEmpty()
                .WithMessage(UiMessages.NotEmptyMessage("Ad"))
                .MinimumLength(3)
                .WithMessage(UiMessages.MinLenghtMessage("Ad", 3))
                .MaximumLength(100)
                .WithMessage(UiMessages.MaxLenghtMessage("Ad", 100));  
            
            RuleFor(x=> x.Comments)
                .NotEmpty()
                .WithMessage(UiMessages.NotEmptyMessage("Mesaj"))
                .MinimumLength(3)
                .WithMessage(UiMessages.MinLenghtMessage("Mesaj", 3))
                .MaximumLength(4000)
                .WithMessage(UiMessages.MaxLenghtMessage("Mesaj", 4000));

            RuleFor(x => x.Phone)
                .NotEmpty()
                .WithMessage(UiMessages.NotEmptyMessage("Mobil nömrə"))
                .MaximumLength(13)
                .WithMessage(UiMessages.MaxLenghtMessage("Mobil nömrə", 13));

            RuleFor(x=> x.Email)
                .NotEmpty()
                .WithMessage(UiMessages.NotEmptyMessage("E-poçt"))
                .MinimumLength(3)
                .WithMessage(UiMessages.MinLenghtMessage("E-poçt", 3))
                .MaximumLength(100)
                .WithMessage(UiMessages.MaxLenghtMessage("E-poçt", 100))
                .EmailAddress()
                .WithMessage(UiMessages.EmailCheckMessage());
        }
    }
}
