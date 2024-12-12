using Entities.Dtos;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public static class FaqMapper
    {
        public static FaqDto ToDto(Faq model)
        {
            FaqDto dto = new FaqDto()
            {
                Id = model.Id,
                Answer = model.Answer,
                Question = model.Question,
                LanguageId = model.LanguageId,
            };

            return dto;
        }

        public static List<FaqDto> ToDto(List<Faq> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }


        public static FaqUpdateDto ToUpdateDto(Faq model)
        {
            FaqUpdateDto updateDto = new FaqUpdateDto()
            {
                Id = model.Id,
                Answer = model.Answer,
                Question = model.Question,
                LanguageId = model.LanguageId,
            };

            return updateDto;
        }

        public static List<FaqUpdateDto> ToUpdateDto(List<Faq> models)
        {
            return models.Select(x => ToUpdateDto(x)).ToList();
        }


        public static Faq ToModel(FaqCreateDto createDto)
        {
            Faq model = new Faq()
            {
                Question = createDto.Question,
                Answer = createDto.Answer,
                LanguageId = createDto.LanguageId,
            };

            return model;
        }

        public static Faq ToModel(FaqDto dto)
        {
            Faq model = new Faq
            {
                Id = dto.Id,
                Question = dto.Question,
                Answer = dto.Answer,
                Deleted = dto.Deleted,
                LanguageId = dto.LanguageId,
            };

            return model;
        }

        public static Faq ToModel(FaqUpdateDto updateDto)
        {
            Faq model = new Faq()
            {
                Id = updateDto.Id,
                Question = updateDto.Question,
                Answer = updateDto.Answer,
                LanguageId = updateDto.LanguageId,
            };

            return model;
        }

    }
}
