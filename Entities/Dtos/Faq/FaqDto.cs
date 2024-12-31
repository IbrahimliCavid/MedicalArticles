﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class FaqDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int Deleted {  get; set; }
        public DateTime CreatedDate { get; set; }
        public int LanguageId { get; set; }

    }
}
