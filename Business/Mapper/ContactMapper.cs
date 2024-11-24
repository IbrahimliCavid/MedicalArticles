using Entities.Dtos;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public static class ContactMapper
    {
        public static ContactDto ToDto(Contact model)
        {
            ContactDto dto = new ContactDto()
            {
                Id = model.Id,
               Name = model.Name,
               Email = model.Email,
               Phone = model.Phone,
               Message = model.Message,
               IsAnswer = model.IsAnswer,
               IsRead = model.IsRead,
            };

            return dto;
        }

        public static List<ContactDto> ToDto(List<Contact> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }


        public static ContactUpdateDto ToUpdateDto(Contact model)
        {
            ContactUpdateDto updateDto = new ContactUpdateDto()
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                Phone= model.Phone,
                Message = model.Message,
                IsAnswer = model.IsAnswer,
                IsRead = model.IsRead,
            };

            return updateDto;
        }

        public static List<ContactUpdateDto> ToUpdateDto(List<Contact> models)
        {
            return models.Select(x => ToUpdateDto(x)).ToList();
        }


        public static Contact ToModel(ContactCreateDto createDto)
        {
            Contact model = new Contact()
            {
                Name = createDto.Name,
                Email = createDto.Email,
                Message = createDto.Message,
                IsRead=createDto.IsRead,
               
            };

            return model;
        }

        public static Contact ToModel(ContactDto dto)
        {
            Contact model = new Contact
            {
                Id = dto.Id,
               Name = dto.Name,
               Email = dto.Email,
               Phone = dto.Phone,
               Message = dto.Message,
               IsAnswer = dto.IsAnswer,
               IsRead = dto.IsRead,
            };

            return model;
        }

        public static Contact ToModel(ContactUpdateDto updateDto)
        {
            Contact model = new Contact()
            {
                Id = updateDto.Id,
                Name = updateDto.Name,
                Email = updateDto.Email,
                Phone = updateDto.Phone,
                Message = updateDto.Message,
                IsAnswer = updateDto.IsAnswer,
                IsRead = updateDto.IsRead
            };

            return model;
        }

    }
}
