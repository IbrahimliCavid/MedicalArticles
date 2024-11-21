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
    public class AdressValidation : AbstractValidator<Adress>
    {
        public AdressValidation()
        {
            RuleFor(x => x.Location)
                .NotEmpty()
                .WithMessage(UiMessages.NotEmptyMessage("Adress"))
                .MaximumLength(300)
                .WithMessage(UiMessages.MaxLenghtMessage("Adress", 300))
                .MinimumLength(3)
                .WithMessage(UiMessages.MinLenghtMessage("Adress", 3));

            RuleFor(x => x.Email)
              .NotEmpty()
              .WithMessage(UiMessages.NotEmptyMessage("E-Poçt"))
              .MaximumLength(100)
              .WithMessage(UiMessages.MaxLenghtMessage("E-Poçt", 300))
              .MinimumLength(3)
              .WithMessage(UiMessages.MinLenghtMessage("E-Poçt", 3))
              .EmailAddress()
              .WithMessage(UiMessages.EmailCheckMessage()); 
            
            RuleFor(x => x.Phone1)
              .NotEmpty()
              .WithMessage(UiMessages.NotEmptyMessage("Telefon nömrəsi"))
              .MaximumLength(15)
              .WithMessage(UiMessages.MaxLenghtMessage("Telefon nömrəsi", 300))
              .MinimumLength(3)
              .WithMessage(UiMessages.MinLenghtMessage("Telefon nömrəsi", 3));
        


        }
    }
}
