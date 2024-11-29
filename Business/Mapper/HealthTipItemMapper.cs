﻿using Entities.Dtos;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public static class HealthTipItemMapper
    {
        public static HealthTipItemDto ToDto(HealthTipItem model)
        {
            HealthTipItemDto dto = new HealthTipItemDto()
            {
                Id = model.Id,
                Text = model.Text,
                Deleted = model.Deleted,
            };

            return dto;
        }

        public static List<HealthTipItemDto> ToDto(List<HealthTipItem> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }


        public static HealthTipItemUpdateDto ToUpdateDto(HealthTipItem model)
        {
            HealthTipItemUpdateDto updateDto = new HealthTipItemUpdateDto()
            {
                Id = model.Id,
                Text = model.Text,
                Deleted = model.Deleted
            };

            return updateDto;
        }

        public static List<HealthTipItemUpdateDto> ToUpdateDto(List<HealthTipItem> models)
        {
            return models.Select(x => ToUpdateDto(x)).ToList();
        }


        public static HealthTipItem ToModel(HealthTipItemCreateDto createDto)
        {
            HealthTipItem model = new HealthTipItem()
            {
                Text = createDto.Text,
            };

            return model;
        }

        public static HealthTipItem Model(HealthTipItemDto dto)
        {
            HealthTipItem model = new HealthTipItem
            {
                Id = dto.Id,
                Text= dto.Text,
                Deleted= dto.Deleted
            };

            return model;
        }

        public static HealthTipItem ToModel(HealthTipItemUpdateDto updateDto)
        {
            HealthTipItem model = new HealthTipItem()
            {
                Id = updateDto.Id,
                Text = updateDto.Text,
                Deleted = updateDto.Deleted
            };

            return model;
        }

    }
}