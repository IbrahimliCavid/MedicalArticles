using Core.Results.Abstract;
using Entities.Dtos;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWhyChooseUsService
    {
        IResult Add(WhyChooseUsCreateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors);
        IResult Update(WhyChooseUsUpdateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
        IDataResult<List<WhyChooseUsDto>> GetAll();
        IDataResult<List<WhyChooseUsDto>> GetAllByLanguage(string culture);
        IDataResult<List<WhyChooseUsDto>> GetAllDeleted();
        IDataResult<WhyChooseUsDto> GetById(int id);
        IResult Restore(int id);
    }
}
