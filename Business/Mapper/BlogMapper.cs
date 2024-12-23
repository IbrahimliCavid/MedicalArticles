using Entities.Dtos;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public static class BlogMapper
    {
        public static BlogDto ToDto(Blog model)
        {
            BlogDto dto = new BlogDto()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Title = model.Title,
                Text = model.Text,
                IsHomePage = model.IsHomePage,
                Comments = model.Comments,
                PhotoUrl = model.PhotoUrl,
                LanguageId = model.LanguageId,
            };

            return dto;
        }

        public static List<BlogDto> ToDto(List<Blog> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }

        public static BlogUpdateDto ToUpdateDto(Blog model)
        {
            BlogUpdateDto dto = new BlogUpdateDto()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Title = model.Title,
                Text = model.Text,
                IsHomePage = model.IsHomePage,
                Comments = model.Comments,
                PhotoUrl= model.PhotoUrl,
                LanguageId = model.LanguageId,
            };

            return dto;
        }

        public static Blog ToModel(BlogDto dto)
        {
            Blog model = new Blog()
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                Title = dto.Title,
                Text = dto.Text,
                IsHomePage = dto.IsHomePage,
                Comments = dto.Comments,
                PhotoUrl= dto.PhotoUrl,
                LanguageId = dto.LanguageId,
            };

            return model;
        }

        public static Blog ToModel(BlogCreateDto createDto)
        {
            Blog model = new Blog()
            {
                Name = createDto.Name,
                Surname = createDto.Surname,
                Title = createDto.Title,
                Text = createDto.Text,
                IsHomePage = createDto.IsHomePage,
                PhotoUrl = createDto.PhotoUrl,
                LanguageId = createDto.LanguageId,
            };

            return model;
        }

        public static Blog ToModel(BlogUpdateDto updateDto)
        {
            Blog model = new Blog()
            {
                Name = updateDto.Name,
                Surname = updateDto.Surname,
                Title = updateDto.Title,
                Text = updateDto.Text,
                IsHomePage = updateDto.IsHomePage,
                Comments = updateDto.Comments,
                PhotoUrl = updateDto.PhotoUrl,
                LanguageId = updateDto.LanguageId,
            };

            return model;
        }
    }
}
