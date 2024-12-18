using Business.BaseMessages;
using DataAccess.SqlServerDBContext;
using Entities.Dtos;
using Entities.TableModels;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class AdressCreateValidation : AbstractValidator<AdressCreateDto>
    {
        private readonly ApplicationDbContext _context;
        public AdressCreateValidation(ApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.LanguageId)
            .Must(languageId => !_context.Adresses.Any(a => a.LanguageId == languageId))
            .WithMessage(UiMessages.DublicatLanguageMessage("adress"));

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
            _context = context;
        }

    }
}
