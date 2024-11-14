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
        IDataResult<List<SlideDto>> GetAll();
        IDataResult<SlideDto> Get(int id);
        IResult Delete(int id);
    }
}
