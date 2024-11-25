using Core.Results.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFaqService
    {
        IResult Add(FaqCreateDto dto);
        IResult Update(FaqUpdateDto dto);
        IDataResult<List<FaqDto>> GetAll();
        IDataResult<List<FaqDto>> GetAllDeleted();
        IDataResult<FaqDto> GetById(int id);
        IResult Restore(int id);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);

    }
}
