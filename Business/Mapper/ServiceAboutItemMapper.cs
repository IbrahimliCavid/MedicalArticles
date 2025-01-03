﻿using Entities.Dtos;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public static class ServiceAboutItemMapper
    {

        public static ServiceAboutItemDto ToDto(ServiceAboutItem model)
        {
            ServiceAboutItemDto dto = new ServiceAboutItemDto()
            {
                Id = model.Id,
                Text = model.Text,
                Deleted = model.Deleted,
                CreatedDate = model.CreatedDate,
            };

            return dto;
        }

        public static List<ServiceAboutItemDto> ToDto(List<ServiceAboutItem> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }


        public static ServiceAboutItemUpdateDto ToUpdateDto(ServiceAboutItem model)
        {
            ServiceAboutItemUpdateDto updateDto = new ServiceAboutItemUpdateDto()
            {
                Id = model.Id,
                Text = model.Text,
                Deleted = model.Deleted,
                CreatedDate = model.CreatedDate,
            };

            return updateDto;
        }

        public static List<ServiceAboutItemUpdateDto> ToUpdateDto(List<ServiceAboutItem> models)
        {
            return models.Select(x => ToUpdateDto(x)).ToList();
        }


        public static ServiceAboutItem ToModel(ServiceAboutItemCreateDto createDto)
        {
            ServiceAboutItem model = new ServiceAboutItem()
            {
                Text = createDto.Text,
                ServiceAboutId = createDto.ServiceAboutId,
            };

            return model;
        }

        public static ServiceAboutItem ToModel(ServiceAboutItemDto dto)
        {
            ServiceAboutItem model = new ServiceAboutItem
            {
                Id = dto.Id,
                Text = dto.Text,
                Deleted = dto.Deleted,
                CreatedDate = dto.CreatedDate,
            };

            return model;
        }

        public static ServiceAboutItem ToModel(ServiceAboutItemUpdateDto updateDto)
        {
            ServiceAboutItem model = new ServiceAboutItem()
            {
                Id = updateDto.Id,
                Text = updateDto.Text,
                ServiceAboutId = updateDto.ServiceAboutId,
                Deleted = updateDto.Deleted,
                CreatedDate = updateDto.CreatedDate
            };

            return model;
        }
    }
}
