﻿using Entities.Dtos;
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
        public static WhyChooseUsDto ToDto(WhyChooseUs model)
        {
            WhyChooseUsDto dto = new WhyChooseUsDto()
            {
                Id = model.Id,
                Description = model.Description,
                PhotoUrl = model.PhotoUrl,
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
                Description = model.Description,
                PhotoUrl = model.PhotoUrl,
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
                Description = createDto.Description,
                PhotoUrl = createDto.PhotoUrl
            };

            return model;
        }

        public static WhyChooseUs ToModel(WhyChooseUsDto dto)
        {
            WhyChooseUs model = new WhyChooseUs
            {
                Id = dto.Id,
                Description = dto.Description,
                PhotoUrl = dto.PhotoUrl,
                Deleted = dto.Deleted,
            };

            return model;
        }

        public static WhyChooseUs ToModel(WhyChooseUsUpdateDto updateDto)
        {
            WhyChooseUs model = new WhyChooseUs()
            {
                Id = updateDto.Id,
                Description = updateDto.Description,
                PhotoUrl = updateDto.PhotoUrl,
                Deleted= updateDto.Deleted,
            };

            return model;
        }

    }
}
