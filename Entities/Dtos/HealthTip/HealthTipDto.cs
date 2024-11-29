using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class HealthTipDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Header { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SubTitle { get; set; }
        public string PhotoUrl { get; set; }
        public int Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ICollection<HealthTipItem> HealthTipItems { get; set; }
    }
}
