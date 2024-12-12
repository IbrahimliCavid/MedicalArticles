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
               Comments = model.Comments,
               IsAnswer = model.IsAnswer,
               IsRead = model.IsRead,
               LanguageId = model.LanguageId,
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
                Comments = model.Comments,
                IsAnswer = model.IsAnswer,
                IsRead = model.IsRead,
                LanguageId  = model.LanguageId,
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
                Phone = createDto.Phone,
                Comments = createDto.Comments,
                LanguageId=createDto.LanguageId,
               
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
                Comments = dto.Comments,
               IsAnswer = dto.IsAnswer,
               IsRead = dto.IsRead,
               LanguageId = dto.LanguageId,
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
                Comments = updateDto.Comments,
                IsAnswer = updateDto.IsAnswer,
                IsRead = updateDto.IsRead,
                LanguageId = updateDto.LanguageId,
            };

            return model;
        }

    }
}
