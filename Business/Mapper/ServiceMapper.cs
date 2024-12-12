using Entities.Dtos;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public static class ServiceMapper
    {
        public static ServiceDto ToDto(Service model)
        {
            ServiceDto dto = new ServiceDto()
            {
                Id = model.Id,
                Description = model.Description,
                Title = model.Title,
                PhotoUrl = model.PhotoUrl,
                LanguageId = model.LanguageId,
                CategoryId = model.CategoryId,
            };
            return dto;
        }

        public static List<ServiceDto> ToDto(List<Service> models) { 
            return models.Select(x => ToDto(x)).ToList();
        }


        public static ServiceUpdateDto ToUpdateDto(Service model)
        {
            ServiceUpdateDto updateDto = new ServiceUpdateDto()
            {
                Id = model.Id,
                Description = model.Description,
                Title = model.Title,
                PhotoUrl = model.PhotoUrl,
                LanguageId = model.LanguageId,
                CategoryId = model.CategoryId,
            };

            return updateDto;
        }

        public static List<ServiceUpdateDto> ToUpdateDto(List<Service> models)
        {
            return models.Select(x => ToUpdateDto(x)).ToList();
        }


        public static Service ToModel(ServiceCreateDto createDto)
        {
            Service model = new Service()
            {
                Title = createDto.Title,
                Description = createDto.Description,
                PhotoUrl = createDto.PhotoUrl,
                LanguageId = createDto.LanguageId,
                CategoryId = createDto.CategoryId,
            };

            return model;
        }

        public static Service ToModel(ServiceDto dto)
        {
            Service model = new Service
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                PhotoUrl = dto.PhotoUrl,
                LanguageId = dto.LanguageId,
                CategoryId = dto.CategoryId,
            };

            return model;
        }

        public static Service ToModel(ServiceUpdateDto updateDto)
        {
            Service model = new Service()
            {
                Id = updateDto.Id,
                Title = updateDto.Title,
                Description = updateDto.Description,
                PhotoUrl = updateDto.PhotoUrl,
                LanguageId = updateDto.LanguageId,
                CategoryId= updateDto.CategoryId,
            };

            return model;
        }
    }
}
