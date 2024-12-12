using Entities.Dtos;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public static class WhyChooseUsItemMapper
    {
        public static WhyChooseUsItemDto ToDto(WhyChooseUsItem model)
        {
            WhyChooseUsItemDto dto = new WhyChooseUsItemDto()
            {
                Id = model.Id,
                Title = model.Title,
                Description = model.Description,
                LanguageId = model.LanguageId,
                Deleted = model.Deleted,
            };

            return dto;
        }

        public static List<WhyChooseUsItemDto> ToDto(List<WhyChooseUsItem> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }


        public static WhyChooseUsItemUpdateDto ToUpdateDto(WhyChooseUsItem model)
        {
            WhyChooseUsItemUpdateDto updateDto = new WhyChooseUsItemUpdateDto()
            {
                Id = model.Id,
                Description = model.Description,
                Title = model.Title,
                LanguageId = model.LanguageId,
                Deleted = model.Deleted,
            };

            return updateDto;
        }

        public static List<WhyChooseUsItemUpdateDto> ToUpdateDto(List<WhyChooseUsItem> models)
        {
            return models.Select(x => ToUpdateDto(x)).ToList();
        }


        public static WhyChooseUsItem ToModel(WhyChooseUsItemCreateDto createDto)
        {
            WhyChooseUsItem model = new WhyChooseUsItem()
            {
                Description = createDto.Description,
                Title = createDto.Title,
                LanguageId = createDto.LanguageId,
                WhyChooseUsId = createDto.WhyChooseUsId,
            };

            return model;
        }

        public static WhyChooseUsItem ToModel(WhyChooseUsItemDto dto)
        {
            WhyChooseUsItem model = new WhyChooseUsItem
            {
                Id = dto.Id,
                Description = dto.Description,
                Title = dto.Title,
                LanguageId = dto.LanguageId,
                Deleted = dto.Deleted,
            };

            return model;
        }

        public static WhyChooseUsItem ToModel(WhyChooseUsItemUpdateDto updateDto)
        {
            WhyChooseUsItem model = new WhyChooseUsItem()
            {
                Id = updateDto.Id,
                Description = updateDto.Description,
                Title = updateDto.Title,
                LanguageId = updateDto.LanguageId,
                Deleted = updateDto.Deleted,
                WhyChooseUsId = updateDto.WhyChooseUsId,
            };

            return model;
        }

    }
}
