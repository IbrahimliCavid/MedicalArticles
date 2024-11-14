using Core.Results.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISosialService
    {
        IResult Add(SosialCreateDto dto);
        IResult Update(SosialUpdateDto dto);
        IDataResult<List<SosialDto>> GetAll();  
        IDataResult<SosialDto> GetById(int id);
        IResult Delete(int id);
    }
}
