using Entities.Dtos;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public static class CategoryMapper
    {
        public static CategoryDto ToDto (Category model)
        {
            CategoryDto dto = new CategoryDto()
            {
                Id = model.Id,
                Name = model.Name,  
                IconName = model.IconName
            };

            return dto;
        }
        
        public static List<CategoryDto> ToDto(List<Category> models)
        {
            return models.Select(x=>ToDto(x)).ToList();
        }

        public static Category ToModel(CategoryDto dto)
        {
            Category model = new Category()
            {
                Id = dto.Id,
                Name = dto.Name,
                IconName = dto.IconName,
                Deleted = dto.Deleted
            };

            return model;
        }
        public static CategoryUpdateDto ToUpdateDto(CategoryDto dto)
        {
            CategoryUpdateDto updateDto = new()
            {
                Name = dto.Name,
                IconName = dto.IconName
            };

            return updateDto;
        }

        public static Category ToModel(CategoryCreateDto createDto)
        {
            Category model = new Category() { 
                Name = createDto.Name,
                IconName = createDto.IconName
            };

            return model;
        }

        public static Category ToModel(CategoryUpdateDto updateDto)
        {
            Category model = new Category()
            {
                Id = updateDto.Id,
                Name = updateDto.Name,
                IconName = updateDto.IconName
            };

            return model;
        }



    }
}
