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
    public class TeamBoardValidation : AbstractValidator<TeamBoard>
    {
        public TeamBoardValidation() {
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

            RuleFor(x => x.Profession)
               .MinimumLength(3)
               .WithMessage(UiMessages.MinLenghtMessage("Pozisiya", 3))
               .MaximumLength(200)
               .WithMessage(UiMessages.MaxLenghtMessage("Pozisiya", 200))
               .NotEmpty()
               .WithMessage(UiMessages.NotEmptyMessage("Pozisiya"));

            RuleFor(x => x.FacebookUrl)
               .MinimumLength(3)
               .WithMessage(UiMessages.MinLenghtMessage("Url", 3))
               .MaximumLength(200)
               .WithMessage(UiMessages.MaxLenghtMessage("Url", 200))
               .NotEmpty()
               .WithMessage(UiMessages.NotEmptyMessage("Url"));

            RuleFor(x => x.LinkedinUrl)
             .MinimumLength(3)
             .WithMessage(UiMessages.MinLenghtMessage("Url", 3))
             .MaximumLength(200)
             .WithMessage(UiMessages.MaxLenghtMessage("Url", 200))
             .NotEmpty()
             .WithMessage(UiMessages.NotEmptyMessage("Url"));

            RuleFor(x => x.InstagramUrl)
             .MinimumLength(3)
             .WithMessage(UiMessages.MinLenghtMessage("Url", 3))
             .MaximumLength(200)
             .WithMessage(UiMessages.MaxLenghtMessage("Url", 200))
             .NotEmpty()
             .WithMessage(UiMessages.NotEmptyMessage("Url"));
        }
    }
}
