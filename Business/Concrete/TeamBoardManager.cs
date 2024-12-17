using Business.Abstract;
using Business.BaseMessages;
using Business.Mapper;
using Core.Extension;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Dtos;
using Entities.TableModels;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Concrete
{
    public class TeamBoardManager : ITeamBoardService
    {
        private readonly ITeamBoardDal _teamBoardDal;
        private readonly IValidator<TeamBoard> _validator;

        public TeamBoardManager(IValidator<TeamBoard> validator, ITeamBoardDal teamBoardDal)
        {
            _validator = validator;
            _teamBoardDal = teamBoardDal;
        }

        public IResult Add(TeamBoardCreateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors)
        {
            TeamBoard model = TeamBoardMapper.ToModel(dto);
            var validator = _validator.Validate(model);
            model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            errors = validator.Errors;

            if (!validator.IsValid)
                return new ErrorResult();


            _teamBoardDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(model.Name));
        }

        public IDataResult<List<TeamBoardDto>> GetAll()
        {
            var data = _teamBoardDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<TeamBoardDto>>(TeamBoardMapper.ToDto(data));
        }

        public IDataResult<List<TeamBoardDto>> GetAllDeleted()
        {
            var data = _teamBoardDal.GetAll(x => x.Deleted != 0);
            return new SuccessDataResult<List<TeamBoardDto>>(TeamBoardMapper.ToDto(data));
        }

        public IDataResult<List<TeamBoardDto>> GetAllByLangauge(string culture)
        {
            var data = _teamBoardDal.GetAllByLanguage(culture);
            return new SuccessDataResult<List<TeamBoardDto>>(TeamBoardMapper.ToDto(data));
        }

        public IDataResult<TeamBoardDto> GetById(int id)
        {
            var data = _teamBoardDal.GetById(id);
            return new SuccessDataResult<TeamBoardDto>(TeamBoardMapper.ToDto(data));
        }

        public IResult HardDelete(int id)
        {
            var data = GetById(id).Data;
            _teamBoardDal.Delete(TeamBoardMapper.ToModel(data));

            return new SuccessResult(UiMessages.SuccessDeletedMessage(data.Name));
        }

        public IResult Restore(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = 0;
            _teamBoardDal.Update(TeamBoardMapper.ToModel(data));
            return new SuccessResult();
        }

        public IResult SoftDelete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _teamBoardDal.Update(TeamBoardMapper.ToModel(data));

            return new SuccessResult(UiMessages.SuccessCopyTrashMessage(data.Name));
        }

        public IResult Update(TeamBoardUpdateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors)
        {
            TeamBoard model = TeamBoardMapper.ToModel(dto);
            TeamBoard existData = TeamBoardMapper.ToModel(GetById(model.Id).Data);
            var validator = _validator.Validate(model);
            errors = validator.Errors;

            if (!validator.IsValid)
                return new ErrorResult();

            if (photoUrl is null)
                model.PhotoUrl = existData.PhotoUrl;
            else
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            model.UpdatedDate = DateTime.Now;
            _teamBoardDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage(model.Name));

        }
    }
}
