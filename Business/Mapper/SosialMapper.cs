using Entities.Dtos;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public static class SosialMapper
    {
        public static SosialDto ToDto(Sosial model)
        {
            SosialDto dto = new SosialDto()
            {
                Id = model.Id,
                WhatsappUrl = model.WhatsappUrl,
                FacebookUrl = model.FacebookUrl,
                InstagramUrl = model.InstagramUrl,
                Telegram  = model.Telegram,
                TwitterUrl = model.TwitterUrl,
                CreatedDate = model.CreatedDate,
                };

            return dto;
        }

        public static List<SosialDto> ToDto(List<Sosial> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }


        public static SosialUpdateDto ToUpdateDto(Sosial model)
        {
            SosialUpdateDto updateDto = new SosialUpdateDto()
            {
                Id = model.Id,
                WhatsappUrl = model.WhatsappUrl,
                FacebookUrl = model.FacebookUrl,
                InstagramUrl = model.InstagramUrl,
                Telegram = model.Telegram,
                TwitterUrl = model.TwitterUrl,
                CreatedDate = model.CreatedDate
            };

            return updateDto;
        }

        public static List<SosialUpdateDto> ToUpdateDto(List<Sosial> models)
        {
            return models.Select(x => ToUpdateDto(x)).ToList();
        }


        public static Sosial ToModel(SosialCreateDto createDto)
        {
            Sosial model = new Sosial()
            {
                WhatsappUrl = createDto.WhatsappUrl,
                FacebookUrl = createDto.FacebookUrl,
                InstagramUrl = createDto.InstagramUrl,
                Telegram = createDto.Telegram,
                TwitterUrl = createDto.TwitterUrl
            };

            return model;
        }

        public static Sosial ToModel(SosialDto dto)
        {
            Sosial model = new Sosial ()
            {
                Id = dto.Id,
                WhatsappUrl = dto.WhatsappUrl,
                FacebookUrl = dto.FacebookUrl,
                InstagramUrl = dto.InstagramUrl,
                Telegram = dto.Telegram,
                TwitterUrl = dto.TwitterUrl,
                CreatedDate = dto.CreatedDate
            };

            return model;
        }

        public static Sosial ToModel(SosialUpdateDto updateDto)
        {
            Sosial model = new Sosial()
            {
                Id = updateDto.Id,
                WhatsappUrl = updateDto.WhatsappUrl,
                FacebookUrl = updateDto.FacebookUrl,
                InstagramUrl = updateDto.InstagramUrl,
                Telegram = updateDto.Telegram,
                TwitterUrl = updateDto.TwitterUrl, 
                CreatedDate = updateDto.CreatedDate
            };

            return model;
        }
    }
}
