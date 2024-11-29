using Core.Results.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IServiceAboutItemService
    {
        IResult Add(ServiceAboutItemCreateDto dto);
        IResult Update(ServiceAboutItemUpdateDto dto);
        IDataResult<List<ServiceAboutItemDto>> GetAll();
        IDataResult<List<ServiceAboutItemDto>> GetAllDeleted();
        IDataResult<ServiceAboutItemDto> GetById(int id);
        IResult Restore(int id);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
    }
}
