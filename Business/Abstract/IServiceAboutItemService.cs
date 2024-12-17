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
    public interface IServiceAboutItemService
    {
        IResult Add(ServiceAboutItemCreateDto dto, out List<ValidationFailure> errors);
        IResult Update(ServiceAboutItemUpdateDto dto, out List<ValidationFailure> errors);
        IDataResult<List<ServiceAboutItemDto>> GetAll();
        IDataResult<List<ServiceAboutItemDto>> GetAllDeleted();
        IDataResult<ServiceAboutItemDto> GetById(int id);
        IResult Restore(int id);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
    }
}
