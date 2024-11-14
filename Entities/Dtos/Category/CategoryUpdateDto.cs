using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CategoryUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconName { get; set; }
        public ICollection<Service> Services { get; set; }

        public static Category ToCategory(CategoryUpdateDto dto)
        {
            Category category = new Category()
            {
                Id = dto.Id,
                Name = dto.Name,
                IconName = dto.IconName,
                Services = dto.Services
            };
            return category;
        }
    }
}
