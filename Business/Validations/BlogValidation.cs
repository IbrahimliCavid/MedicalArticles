﻿using Business.BaseMessages;
using Entities.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class BlogValidation : AbstractValidator<Blog>
    {
        public BlogValidation()
        {
            RuleFor(x => x.Name)
               .MinimumLength(3)
               .WithMessage(UiMessages.MinLenghtMessage("Ad", 3))
               .MaximumLength(100)
               .WithMessage(UiMessages.MaxLenghtMessage("Ad", 100))
               .NotEmpty()
               .WithMessage(UiMessages.NotEmptyMessage("Ad"));

            RuleFor(x => x.Surname)
               .MaximumLength(100)
               .WithMessage(UiMessages.MaxLenghtMessage("Soyad", 100));
               

            RuleFor(x => x.Title)
               .MinimumLength(3)
               .WithMessage(UiMessages.MinLenghtMessage("Başlıq", 3))
               .MaximumLength(500)
               .WithMessage(UiMessages.MaxLenghtMessage("Başlıq", 500))
               .NotEmpty()
               .WithMessage(UiMessages.NotEmptyMessage("Başlıq"));

            RuleFor(x => x.Text)
               .MinimumLength(3)
               .WithMessage(UiMessages.MinLenghtMessage("Mətn", 3))
               .MaximumLength(5000)
               .WithMessage(UiMessages.MaxLenghtMessage("Mətn", 5000))
               .NotEmpty()
               .WithMessage(UiMessages.NotEmptyMessage("Mətn"));

        }
    }
}
