﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class StatisticUpdateDto
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int Count { get; set; }
        public int LanguageId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
