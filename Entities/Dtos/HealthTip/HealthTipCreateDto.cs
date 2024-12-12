using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class HealthTipCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Header { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubTitle { get; set; }
        public string PhotoUrl { get; set; }
        public int LanguageId { get; set; }

    }
}
