﻿using Entities.Dtos;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public static class ServiceAboutMapper
    {
        public static ServiceAboutDto ToDto(ServiceAbout model)
        {
            ServiceAboutDto dto = new ServiceAboutDto()
            {
                Id = model.Id,
                Description = model.Description,
                Title = model.Title,
                PhotoUrl = model.PhotoUrl,
                Deleted = model.Deleted,
            };

            return dto;
        }

        public static List<ServiceAboutDto> ToDto(List<ServiceAbout> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }


        public static ServiceAboutUpdateDto ToUpdateDto(ServiceAbout model)
        {
            ServiceAboutUpdateDto updateDto = new ServiceAboutUpdateDto()
            {
                Id = model.Id,
                Description = model.Description,
                Title = model.Title,
                PhotoUrl = model.PhotoUrl,
                Deleted = model.Deleted,
            };

            return updateDto;
        }

        public static List<ServiceAboutUpdateDto> ToUpdateDto(List<ServiceAbout> models)
        {
            return models.Select(x => ToUpdateDto(x)).ToList();
        }


        public static ServiceAbout ToModel(ServiceAboutCreateDto createDto)
        {
            ServiceAbout model = new ServiceAbout()
            {
                Title = createDto.Title,
                Description = createDto.Description,
                PhotoUrl = createDto.PhotoUrl
            };

            return model;
        }

        public static ServiceAbout ToModel(ServiceAboutDto dto)
        {
            ServiceAbout model = new ServiceAbout
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                PhotoUrl = dto.PhotoUrl,
                Deleted = dto.Deleted,
            };

            return model;
        }

        public static ServiceAbout ToModel(ServiceAboutUpdateDto updateDto)
        {
            ServiceAbout model = new ServiceAbout()
            {
                Id = updateDto.Id,
                Title = updateDto.Title,
                Description = updateDto.Description,
                PhotoUrl = updateDto.PhotoUrl,
                Deleted= updateDto.Deleted,
            };

            return model;
        }
    }
}