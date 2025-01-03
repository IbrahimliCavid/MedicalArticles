﻿using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class WhyChooseUsDto
    {
        public int Id {  get; set; }
        public string Header { get; set; }
        public string PhotoUrl { get; set; }
        public int Deleted {  get; set; }
        public int LanguageId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<WhyChooseUsItem> WhyChooseUsItems { get; set; }
    }
}
