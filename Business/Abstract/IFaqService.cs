using Core.Results.Abstract;
using Entities.Dtos;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFaqService
    {
        IResult Add(FaqCreateDto dto, out List<ValidationFailure> errors);
        IResult Update(FaqUpdateDto dto, out List<ValidationFailure> errors);
        IDataResult<List<FaqDto>> GetAll();
        IDataResult<List<FaqDto>> GetAllByLanguage(string culture);
        IDataResult<List<FaqDto>> GetAllDeleted();
        IDataResult<FaqDto> GetById(int id);
        IResult Restore(int id);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);

    }
}
