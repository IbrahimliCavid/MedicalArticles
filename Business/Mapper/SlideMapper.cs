﻿using Entities.Dtos;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public static class SlideMapper
    {
        public static SlideDto ToDto(Slide model)
        {
            SlideDto dto = new SlideDto()
            {
                Id = model.Id,
                Content = model.Content,
                Title = model.Title,
                PhotoUrl = model.PhotoUrl,
                LanguageId = model.LanguageId,
                Deleted = model.Deleted,
                CreatedDate = model.CreatedDate,
                
            };

            return dto;
        }

        public static List<SlideDto> ToDto(List<Slide> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }


        public static SlideUpdateDto ToUpdateDto(Slide model)
        {
            SlideUpdateDto updateDto = new SlideUpdateDto()
            {
                Id = model.Id,
                Content = model.Content,
                Title = model.Title,
                LanguageId = model.LanguageId,
                PhotoUrl = model.PhotoUrl,
                Deleted = model.Deleted,
                CreatedDate = model.CreatedDate
            };

            return updateDto;
        }

        public static List<SlideUpdateDto> ToUpdateDto(List<Slide> models)
        {
            return models.Select(x => ToUpdateDto(x)).ToList();
        }


        public static Slide ToModel(SlideCreateDto createDto)
        {
            Slide model = new Slide()
            {
                Title = createDto.Title,
                Content = createDto.Content,
                PhotoUrl = createDto.PhotoUrl,
                LanguageId = createDto.LanguageId,
                Deleted = createDto.Deleted,
            };

            return model;
        }

        public static Slide ToModel(SlideDto dto)
        {
            Slide model = new Slide
            {
                Id = dto.Id,
                Title = dto.Title,
                Content = dto.Content,
                LanguageId = dto.LanguageId,
                PhotoUrl = dto.PhotoUrl,
                Deleted = dto.Deleted,
                CreatedDate = dto.CreatedDate
            };

            return model;
        }

        public static Slide ToModel(SlideUpdateDto updateDto)
        {
            Slide model = new Slide()
            {
                Id = updateDto.Id,
                Title = updateDto.Title,
                Content = updateDto.Content,
                PhotoUrl = updateDto.PhotoUrl,
                LanguageId = updateDto.LanguageId,
                Deleted= updateDto.Deleted,
                CreatedDate= updateDto.CreatedDate
            };

            return model;
        }
    }
}
