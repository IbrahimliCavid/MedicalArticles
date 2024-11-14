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
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
              .WithMessage(UiMessages.NotEmptyMessage("Kateqoriya adı"))
            .MinimumLength(3)
              .WithMessage(UiMessages.MinLenghtMessage("Kateqoriya adı", 3))
            .MaximumLength(100)
              .WithMessage(UiMessages.MaxLenghtMessage("Kateqoriya adı", 100));

               RuleFor(x => x.IconName)
            .NotEmpty()
              .WithMessage(UiMessages.NotEmptyMessage("Ikon adı"))
            .MinimumLength(3)
              .WithMessage(UiMessages.MinLenghtMessage("Ikon adı", 3))
            .MaximumLength(100)
              .WithMessage(UiMessages.MaxLenghtMessage("Ikon adı", 100));
        }
    }
}
