using Entities.Dtos;
using Entities.TableModels;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public static class AboutMapper
    {
        public static AboutDto ToDto(About model)
        {
            AboutDto dto = new AboutDto()
            {
                Id = model.Id,
                Description = model.Description,
                Title = model.Title,
                PhotoUrl = model.PhotoUrl
            };

            return dto;
        }

        public static List<AboutDto> ToDto(List<About> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }


        public static AboutUpdateDto ToUpdateDto(About model)
        {
            AboutUpdateDto updateDto = new AboutUpdateDto()
            {
                Id = model.Id,
                Description = model.Description,
                Title = model.Title,
                PhotoUrl = model.PhotoUrl
            };

            return updateDto;
        }

        public static List<AboutUpdateDto> ToUpdateDto(List<About> models)
        {
            return models.Select(x => ToUpdateDto(x)).ToList();
        }


        public static About ToModel(AboutCreateDto createDto)
        {
            About model = new About() { 
                 Title = createDto.Title,
                 Description = createDto.Description,
                 PhotoUrl = createDto.PhotoUrl
            };

            return model;
        }

        public static About ToModel(AboutDto dto)
        {
            About model = new About
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                PhotoUrl = dto.PhotoUrl
            };

            return model;
        }

        public static About ToModel (AboutUpdateDto updateDto)
        {
            About model = new About()
            {
                Id = updateDto.Id,
                Title = updateDto.Title,
                Description = updateDto.Description,
                PhotoUrl = updateDto.PhotoUrl,
            };

            return model;
        }

    }
}
