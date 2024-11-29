﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TableModels
{
    public class WhyChooseUsItem : BaseEntity
    {
        public string Titile {  get; set; }
        public string Description {  get; set; }
        public int WhyChooseUsId {  get; set; }
        public virtual WhyChooseUs WhyChooseUs { get; set; }
    }
}
