using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconName { get; set; }
        public int Deleted {  get; set; }
        public virtual ICollection<Service> Services { get; set; }
        public int LanguageId { get; set; }

    }
}
