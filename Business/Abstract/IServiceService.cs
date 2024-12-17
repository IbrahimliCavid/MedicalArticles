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
    public interface IServiceService
    {
        IResult Add(ServiceCreateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors);
        IResult Update(ServiceUpdateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors);
        IDataResult<List<ServiceDto>> GetAll();
        IDataResult<List<ServiceDto>> GetAllByLanguage(string culture);
        IDataResult<List<ServiceDto>> GetAllDeleted();
        IDataResult<ServiceDto> GetById(int id);
        IResult SoftDelete(int id); 
        IResult HardDelete(int id); 
        IResult Restore(int id);
    }
}
