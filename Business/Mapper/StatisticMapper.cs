using Entities.Dtos;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public class StatisticMapper
    {
        public static StatisticDto ToDto(Statistic model)
        {
            StatisticDto dto = new StatisticDto()
            {
                Id = model.Id,
                Name = model.Name,
                Count = model.Count,
                Icon = model.Icon,
            };

            return dto;
        }

        public static List<StatisticDto> ToDto(List<Statistic> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }

        public static Statistic ToModel(StatisticDto dto)
        {
            Statistic model = new Statistic()
            {
                Id = dto.Id,
                Name = dto.Name,
                Count = dto.Count,
                Icon = dto.Icon,
                Deleted = dto.Deleted
            };

            return model;
        }
        public static StatisticUpdateDto ToUpdateDto(StatisticDto dto)
        {
            StatisticUpdateDto updateDto = new()
            {
                Name = dto.Name,
                Count  = dto.Count,
                Icon = dto.Icon
            };

            return updateDto;
        }

        public static Statistic ToModel(StatisticCreateDto createDto)
        {
            Statistic model = new Statistic()
            {
                Name = createDto.Name,
                Count= createDto.Count,
                Icon = createDto.Icon
            };

            return model;
        }

        public static Statistic ToModel(StatisticUpdateDto updateDto)
        {
            Statistic model = new Statistic()
            {
                Id = updateDto.Id,
                Name = updateDto.Name,
                Count = updateDto.Count,
                Icon = updateDto.Icon
            };

            return model;
        }
    }
}
