﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TableModels
{
    public class WhyChooseUs : BaseEntity
    {
        public WhyChooseUs()
        {
            WhyChooseUsItems = new HashSet<WhyChooseUsItem>();
        }
        public string Header {  get; set; }
        public string PhotoUrl { get; set; }
        public virtual ICollection<WhyChooseUsItem> WhyChooseUsItems { get; set; }

        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}
