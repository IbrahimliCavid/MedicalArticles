using Entities.Dtos;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public static class WhyChooseUsMapper
    {
        public static WhyChooseUsDto ToDto(WhyChooseUs model)
        {
            WhyChooseUsDto dto = new WhyChooseUsDto()
            {
                Id = model.Id,
                Header = model.Header,
                PhotoUrl = model.PhotoUrl,
                LanguageId = model.LanguageId,
                Deleted = model.Deleted,
            };

            return dto;
        }

        public static List<WhyChooseUsDto> ToDto(List<WhyChooseUs> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }


        public static WhyChooseUsUpdateDto ToUpdateDto(WhyChooseUs model)
        {
            WhyChooseUsUpdateDto updateDto = new WhyChooseUsUpdateDto()
            {
                Id = model.Id,
                Header = model.Header,
                PhotoUrl = model.PhotoUrl,
                LanguageId=model.LanguageId,
                Deleted = model.Deleted,
            };

            return updateDto;
        }

        public static List<WhyChooseUsUpdateDto> ToUpdateDto(List<WhyChooseUs> models)
        {
            return models.Select(x => ToUpdateDto(x)).ToList();
        }


        public static WhyChooseUs ToModel(WhyChooseUsCreateDto createDto)
        {
            WhyChooseUs model = new WhyChooseUs()
            {
                Header = createDto.Header,
                PhotoUrl = createDto.PhotoUrl,
                LanguageId=createDto.LanguageId,
            };

            return model;
        }

        public static WhyChooseUs ToModel(WhyChooseUsDto dto)
        {
            WhyChooseUs model = new WhyChooseUs
            {
                Id = dto.Id,
                Header = dto.Header,
                PhotoUrl = dto.PhotoUrl,
                LanguageId=dto.LanguageId,
                Deleted= dto.Deleted,
            };

            return model;
        }

        public static WhyChooseUs ToModel(WhyChooseUsUpdateDto updateDto)
        {
            WhyChooseUs model = new WhyChooseUs()
            {
                Id = updateDto.Id,
                Header = updateDto.Header,
                PhotoUrl = updateDto.PhotoUrl,
                LanguageId=updateDto.LanguageId,
                Deleted = updateDto.Deleted,
            };

            return model;
        }
    }
}
