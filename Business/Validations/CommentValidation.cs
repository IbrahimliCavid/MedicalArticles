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
    public class CommentValidation : AbstractValidator<Comment>
    {
        public CommentValidation()
        {
            RuleFor(x => x.Name)
              .MinimumLength(3)
              .WithMessage(UiMessages.MinLenghtMessage("Ad", 3))
              .MaximumLength(100)
              .WithMessage(UiMessages.MaxLenghtMessage("Ad", 100))
              .NotEmpty()
              .WithMessage(UiMessages.NotEmptyMessage("Ad"));

            RuleFor(x => x.Content)
               .MinimumLength(3)
               .WithMessage(UiMessages.MinLenghtMessage("Comment", 3))
               .MaximumLength(5000)
               .WithMessage(UiMessages.MaxLenghtMessage("Comment", 5000))
               .NotEmpty()
               .WithMessage(UiMessages.NotEmptyMessage("Comment"));
        }
    }
}
