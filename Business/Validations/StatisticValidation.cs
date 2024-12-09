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
    public class StatisticValidation : AbstractValidator<Statistic>
    {
        public StatisticValidation() {

            RuleFor(x => x.Name)
          .NotEmpty()
            .WithMessage(UiMessages.NotEmptyMessage("Ad"))
          .MinimumLength(3)
            .WithMessage(UiMessages.MinLenghtMessage("Ad", 3))
          .MaximumLength(100)
            .WithMessage(UiMessages.MaxLenghtMessage("Ad", 100));

            RuleFor(x => x.Icon)
         .NotEmpty()
           .WithMessage(UiMessages.NotEmptyMessage("Ikon"))
         .MinimumLength(3)
           .WithMessage(UiMessages.MinLenghtMessage("Ikon", 3))
         .MaximumLength(100)
           .WithMessage(UiMessages.MaxLenghtMessage("Ikon", 100));
        }
    }
}
