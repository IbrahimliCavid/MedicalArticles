using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class WhyChooseUsUpdateDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public int Deleted { get; set; }
    }
}
