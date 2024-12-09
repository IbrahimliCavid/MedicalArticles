using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IStatisticService 
    {
        IResult Add(StatisticCreateDto dto);
        IResult Update(StatisticUpdateDto dto);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
        IDataResult<List<StatisticDto>> GetAll();
        IDataResult<List<StatisticDto>> GetAllDeleted();
        IDataResult<StatisticDto> GetById(int id);
        IResult Restore(int id);
    }
}
