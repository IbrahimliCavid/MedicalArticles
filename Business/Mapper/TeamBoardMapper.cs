using Entities.Dtos;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public static class TeamBoardMapper
    {
        public static TeamBoardDto ToDto(TeamBoard model)
        {
            TeamBoardDto dto = new TeamBoardDto()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Profession = model.Profession,
                PhotoUrl = model.PhotoUrl,
                FacebookUrl = model.FacebookUrl,
                LinkedinUrl = model.LinkedinUrl,
                InstagramUrl = model.InstagramUrl,
                IsHomePage = model.IsHomePage,
                LanguageId  = model.LanguageId,
                Deleted = model.Deleted,
            };

            return dto;
        }

        public static List<TeamBoardDto> ToDto(List<TeamBoard> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }


        public static TeamBoardUpdateDto ToUpdateDto(TeamBoard model)
        {
            TeamBoardUpdateDto updateDto = new TeamBoardUpdateDto()
            {
                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                Profession = model.Profession,
                PhotoUrl = model.PhotoUrl,
                FacebookUrl = model.FacebookUrl,
                LinkedinUrl = model.LinkedinUrl,
                InstagramUrl = model.InstagramUrl,
                LanguageId = model.LanguageId,
                IsHomePage= model.IsHomePage,
                Deleted = model.Deleted,
            };

            return updateDto;
        }

        public static List<TeamBoardUpdateDto> ToUpdateDto(List<TeamBoard> models)
        {
            return models.Select(x => ToUpdateDto(x)).ToList();
        }


        public static TeamBoard ToModel(TeamBoardCreateDto createDto)
        {
            TeamBoard model = new TeamBoard()
            {
                Name = createDto.Name,
                Surname = createDto.Surname,
                Profession = createDto.Profession,
                PhotoUrl = createDto.PhotoUrl,
                FacebookUrl = createDto.FacebookUrl,
                LinkedinUrl = createDto.LinkedinUrl,
                InstagramUrl = createDto.InstagramUrl,
                IsHomePage = createDto.IsHomePage,
                LanguageId = createDto.LanguageId,
            };

            return model;
        }

        public static TeamBoard ToModel(TeamBoardDto dto)
        {
            TeamBoard model = new TeamBoard
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                Profession = dto.Profession,
                PhotoUrl = dto.PhotoUrl,
                FacebookUrl = dto.FacebookUrl,
                LinkedinUrl = dto.LinkedinUrl,
                InstagramUrl = dto.InstagramUrl,
                LanguageId = dto.LanguageId,
                IsHomePage= dto.IsHomePage,
                Deleted = dto.Deleted
            };

            return model;
        }

        public static TeamBoard ToModel(TeamBoardUpdateDto updateDto)
        {
            TeamBoard model = new TeamBoard()
            {
                Id = updateDto.Id,
                Name = updateDto.Name,
                Surname = updateDto.Surname,
                Profession = updateDto.Profession,
                PhotoUrl = updateDto.PhotoUrl,
                FacebookUrl = updateDto.FacebookUrl,
                LinkedinUrl = updateDto.LinkedinUrl,
                InstagramUrl = updateDto.InstagramUrl,
                IsHomePage = updateDto.IsHomePage,
                LanguageId = updateDto.LanguageId,
                Deleted = updateDto.Deleted
            };

            return model;
        }
    }
}
