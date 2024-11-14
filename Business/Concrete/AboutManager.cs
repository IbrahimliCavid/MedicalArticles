using Business.Abstract;
using Business.BaseMessages;
using Business.Mapper;
using Core.Extension;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        private readonly IValidator<About> _validator;

        public AboutManager(IValidator<About> validator, IAboutDal aboutDal)
        {
            _validator = validator;
            _aboutDal = aboutDal;
        }

        public IResult Add(AboutCreateDto dto, IFormFile photoUrl, string webRootPath)
        {
            About model = AboutCreateDto.ToAbout(dto);
            var validator = _validator.Validate(model);
            model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);  

            string errorMessage = "";

            foreach(var error in validator.Errors)
            {
                errorMessage = error.ErrorMessage;
            }

            if(!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }

            _aboutDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(model.Title));
        }

        public IDataResult<List<AboutDto>> GetAll()
        {
            var data = _aboutDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<AboutDto>>(AboutMapper.ToDto(data));
        }

        public IDataResult<List<AboutDto>> GetAllDeleted()
        {
            var data = _aboutDal.GetAll(x => x.Deleted != 0);
            return new SuccessDataResult<List<AboutDto>>(AboutMapper.ToDto(data));
        }

        public IDataResult<About> GetById(int id)
        {
            return new SuccessDataResult<About>(_aboutDal.GetById(id));
        }

        public IResult HardDelete(int id)
        {
            var data  = GetById(id).Data;
            _aboutDal.Delete(data);

            return new SuccessResult(UiMessages.SuccessDeletedMessage(data.Title));
        }

        public IResult Restore(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = 0;
            _aboutDal.Update(data);
            return new SuccessResult();
        }

        public IResult SoftDelete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _aboutDal.Update(data);

            return new  SuccessResult(UiMessages.SuccessCopyTrashMessage(data.Title));
        }

        public IResult Update(AboutUpdateDto dto, IFormFile photoUrl, string webRootPath)
        {
            About model = AboutUpdateDto.ToAbout(dto);
            About existData = GetById(model.Id).Data;
            
            if(photoUrl is null)
                model.PhotoUrl = existData.PhotoUrl;
            else
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            model.UpdatedDate = DateTime.Now;
            _aboutDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage(model.Title));
            
        }
    }
}
