using Core.Results.Abstract;
using Entities.Dtos;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHealthTipItemService
    {
        IResult Add(HealthTipItemCreateDto dto, out List<ValidationFailure> errors);
        IResult Update(HealthTipItemUpdateDto dto, out List<ValidationFailure> errors);
        IDataResult<List<HealthTipItemDto>> GetAll();
        IDataResult<List<HealthTipItemDto>> GetAllDeleted();
        IDataResult<HealthTipItemDto> GetById(int id);
        IResult Restore(int id);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
    }
}
