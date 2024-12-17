using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutService
    {
        IResult Add(AboutCreateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors);
        IResult Update (AboutUpdateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors);
        IResult SoftDelete(int  id);
        IResult HardDelete(int  id);
        IDataResult<List<AboutDto>> GetAll();
        IDataResult<List<AboutDto>> GetAllDeleted();
        IDataResult<About> GetById(int id);
        IResult Restore(int id);
    }
}
