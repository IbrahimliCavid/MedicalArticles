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
    public interface ITeamBoardService
    {
        IResult Add(TeamBoardCreateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Update(TeamBoardUpdateDto dto, IFormFile photoUrl, string webRootPath);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
        IDataResult<List<TeamBoardDto>> GetAll();
        IDataResult<List<TeamBoardDto>> GetAllByLangauge(string culture);
        IDataResult<List<TeamBoardDto>> GetAllDeleted();
        IDataResult<TeamBoardDto> GetById(int id);
        IResult Restore(int id);
    }
}
