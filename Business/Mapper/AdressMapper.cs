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
    public static class AdressMapper
    {
        public static AdressDto ToDto(Adress model)
        {
            AdressDto dto = new AdressDto()
            {
                Id = model.Id,
                Location = model.Location,
                Phone1 = model.Phone1,
                Phone2 = model.Phone2,
                Phone3 = model.Phone3,
                Email = model.Email,
                LanguageId = model.LanguageId,
            };

            return dto;
        }

        public static List<AdressDto> ToDto(List<Adress> models)
        {
            return models.Select(x=>ToDto(x)).ToList(); 
        }

        public static AdressUpdateDto ToUpdateDto(Adress model)
        {
            AdressUpdateDto dto = new AdressUpdateDto()
            {
                Id = model.Id,
                Location = model.Location,
                Phone1 = model.Phone1,
                Phone2 = model.Phone2,
                Phone3 = model.Phone3,
                Email = model.Email,
                LanguageId=model.LanguageId,
            };

            return dto;
        }

        public static Adress ToModel(AdressDto dto)
        {
            Adress model = new Adress()
            {
                Id = dto.Id,
                Location = dto.Location,
                Phone1 = dto.Phone1,
                Phone2 = dto.Phone2,
                Phone3 = dto.Phone3,
                Email = dto.Email,
                LanguageId  = dto.LanguageId,
            };

            return model;
        }

        public static Adress ToModel(AdressCreateDto createDto)
        {
            Adress model = new Adress()
            {
                Location = createDto.Location,
                Phone1 = createDto.Phone1,
                Phone2 = createDto.Phone2,
                Phone3 = createDto.Phone3,
                Email = createDto.Email,
                LanguageId = createDto.LanguageId,
            };

            return model;
        }

        public static Adress ToModel(AdressUpdateDto updateDto)
        {
            Adress model = new Adress()
            {
                Id = updateDto.Id,
                Location = updateDto.Location,
                Phone1 = updateDto.Phone1,
                Phone2 = updateDto.Phone2,
                Phone3 = updateDto.Phone3,
                Email = updateDto.Email,
                LanguageId = updateDto.LanguageId,
            };

            return model;
        }

    }
}
