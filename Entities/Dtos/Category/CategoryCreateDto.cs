using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CategoryCreateDto
    {
        public string Name { get; set; }
        public string IconName { get; set; }
        public ICollection<Service> Services { get; set; }

     
    }
}
