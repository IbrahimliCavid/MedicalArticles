﻿using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class HealthTipItemDto
    {
        public int Id { get; set; } 
        public string Text { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Header { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubTitle { get; set; }
        public string PhotoUrl { get; set; }
        public int HealthTipId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Deleted {  get; set; }
        public virtual HealthTip HealthTip { get; set; }
    }
}
