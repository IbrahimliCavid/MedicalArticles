using Core.Results.Abstract;
using Entities.Dtos;
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
        IResult Add(SlideCreateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Update(SlideUpdateDto dto, IFormFile photoUrl, string webRootPath);
        IDataResult<List<SlideDto>> GetAll(string lang);
        IDataResult<List<SlideDto>> GetAllDeleted();
        IDataResult<SlideDto> GetById(int id);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
        IResult Restore(int id);    
    }
}
