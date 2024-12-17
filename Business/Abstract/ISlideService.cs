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
    public interface ISlideService
    {
        IResult Add(SlideCreateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors);
        IResult Update(SlideUpdateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors);
        IDataResult<List<SlideDto>> GetAllByLanguage(string culture);
        IDataResult<List<SlideDto>> GetAllDeleted();
        IDataResult<List<SlideDto>> GetAll();
        IDataResult<SlideDto> GetById(int id);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
        IResult Restore(int id);    
    }
}
