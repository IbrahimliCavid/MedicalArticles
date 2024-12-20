﻿using Business.BaseMessages;
using DataAccess.SqlServerDBContext;
using Entities.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations
{
    public class WhyChooseUsValidation : AbstractValidator<WhyChooseUs>
    {
        
        public WhyChooseUsValidation()
        {

            RuleFor(x => x.Header)
              .MinimumLength(3)
              .WithMessage(UiMessages.MinLenghtMessage("Açıqlama", 3))
              .MaximumLength(3000)
              .WithMessage(UiMessages.MaxLenghtMessage("Açıqlama", 3000))
              .NotEmpty()
              .WithMessage(UiMessages.NotEmptyMessage("Açıqlama"));
        }
    }
}
