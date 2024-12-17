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
    public interface ISosialService
    {
        IResult Add(SosialCreateDto dto, out List<ValidationFailure> errors);
        IResult Update(SosialUpdateDto dto, out List<ValidationFailure> errors);
        IDataResult<List<SosialDto>> GetAll();  
        IDataResult<SosialDto> GetById(int id);
    }
}
