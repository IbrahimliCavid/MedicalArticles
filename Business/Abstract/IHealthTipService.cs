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
    public interface IHealthTipService
    {
        IResult Add(HealthTipCreateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors);
        IResult Update(HealthTipUpdateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
        IDataResult<List<HealthTipDto>> GetAll();
        IDataResult<List<HealthTipDto>> GetAllByLanguage(string culture);
        IDataResult<List<HealthTipDto>> GetAllDeleted();
        IDataResult<HealthTip> GetById(int id);
        IResult Restore(int id);
    }
}
