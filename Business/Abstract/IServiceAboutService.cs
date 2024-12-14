using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IServiceAboutService
    {
        IResult Add(ServiceAboutCreateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Update(ServiceAboutUpdateDto dto, IFormFile photoUrl, string webRootPath);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
        IDataResult<List<ServiceAboutDto>> GetAll();
        IDataResult<List<ServiceAboutDto>> GetAllByLanguage(string culture);
        IDataResult<List<ServiceAboutDto>> GetAllDeleted();
        IDataResult<ServiceAboutDto> GetById(int id);
        IResult Restore(int id);
    }
}
