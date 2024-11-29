using Entities.Dtos;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public static class HealthTipMapper
    {
        public static HealthTipDto ToDto(HealthTip model)
        {
            HealthTipDto dto = new HealthTipDto()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Header = model.Header,
                Description = model.Description,
                Title = model.Title,
                SubTitle = model.SubTitle,
                PhotoUrl = model.PhotoUrl,
                Deleted = model.Deleted,
            };

            return dto;
        }

        public static List<HealthTipDto> ToDto(List<HealthTip> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }


        public static HealthTipUpdateDto ToUpdateDto(HealthTip model)
        {
            HealthTipUpdateDto updateDto = new HealthTipUpdateDto()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Header = model.Header,
                Description = model.Description,
                Title = model.Title,
                SubTitle = model.SubTitle,
                PhotoUrl = model.PhotoUrl,
                Deleted = model.Deleted,
            };

            return updateDto;
        }

        public static List<HealthTipUpdateDto> ToUpdateDto(List<HealthTip> models)
        {
            return models.Select(x => ToUpdateDto(x)).ToList();
        }


        public static HealthTip ToModel(HealthTipCreateDto createDto)
        {
            HealthTip model = new HealthTip()
            {
                Name = createDto.Name,
                Surname = createDto.Surname,
                Header = createDto.Header,
                Description = createDto.Description,
                Title = createDto.Title,
                SubTitle = createDto.SubTitle,
                PhotoUrl = createDto.PhotoUrl,
            };

            return model;
        }

        public static HealthTip ToModel(HealthTipDto dto)
        {
            HealthTip model = new HealthTip
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                Header = dto.Header,
                Description = dto.Description,
                Title = dto.Title,
                SubTitle = dto.SubTitle,
                PhotoUrl = dto.PhotoUrl,
                Deleted = dto.Deleted,
            };

            return model;
        }

        public static HealthTip ToModel(HealthTipUpdateDto updateDto)
        {
            HealthTip model = new HealthTip()
            {
                Id = updateDto.Id,
                Name = updateDto.Name,
                Surname = updateDto.Surname,
                Header = updateDto.Header,
                Description = updateDto.Description,
                Title = updateDto.Title,
                SubTitle = updateDto.SubTitle,
                PhotoUrl = updateDto.PhotoUrl,
                Deleted = updateDto.Deleted,
            };

            return model;
        }

    }
}
}
