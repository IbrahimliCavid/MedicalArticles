using Core.Results.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWhyChooseUsItemService
    {
        IResult Add(WhyChooseUsItemCraeteDto dto);
        IResult Update(WhyChooseUsItemUpdateDto dto);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
        IDataResult<List<WhyChooseUsItemDto>> GetAll();
        IDataResult<List<WhyChooseUsItemDto>> GetAllDeleted();
        IDataResult<WhyChooseUsItemDto> GetById(int id);
        IResult Restore(int id);
    }
}
