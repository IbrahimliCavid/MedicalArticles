using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class WhyChooseUsCreateDto
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string PhotoUrl { get; set; }
        public int Deleted { get; set; }
    }
}
