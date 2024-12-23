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
    public interface IBlogService
    {
        IResult Add(BlogCreateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors);
        IResult Update(BlogUpdateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
        IDataResult<List<BlogDto>> GetAll();
        IDataResult<List<BlogDto>> GetAllByLangauge(string culture);
        IDataResult<List<BlogDto>> GetAllDeleted();
        IDataResult<BlogDto> GetById(int id);
        IResult Restore(int id);
    }
}
