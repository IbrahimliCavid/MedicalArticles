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
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Concrete
{
    public class ServiceAboutManager : IServiceAboutService
    {
        private readonly IServiceAboutDal _serviceAboutDal;
        private readonly IValidator<ServiceAbout> _validator;

        public ServiceAboutManager(IValidator<ServiceAbout> validator, IServiceAboutDal serviceAboutDal)
        {
            _validator = validator;
            _serviceAboutDal = serviceAboutDal;
        }
        public class Test
        {
            public string PropertyName { get; set; }
            public string ErrorMessage { get; set; }
        } 
        public IResult Add(ServiceAboutCreateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors)
        {
            ServiceAbout model = ServiceAboutMapper.ToModel(dto);
             var validator = _validator.Validate(model);
            errors = validator.Errors;

            if (!validator.IsValid || photoUrl == null || photoUrl.Length <= 0)
            {
                errors.Add(new ValidationFailure("PhotoUrl", UiMessages.NotEmptyMessage("Foto")));
                return new ErrorResult();
            }

            model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);
            _serviceAboutDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(model.Title));
        }

        public IDataResult<List<ServiceAboutDto>> GetAll()
        {
            var data = _serviceAboutDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<ServiceAboutDto>>(ServiceAboutMapper.ToDto(data));
        }
        
        public IDataResult<List<ServiceAboutDto>> GetAllByLanguage(string culture)
        {
            var data = _serviceAboutDal.GetAllServiceWithItems(culture);
            return new SuccessDataResult<List<ServiceAboutDto>>(data);
        }

        public IDataResult<List<ServiceAboutDto>> GetAllDeleted()
        {
            var data = _serviceAboutDal.GetAll(x => x.Deleted != 0);
            return new SuccessDataResult<List<ServiceAboutDto>>(ServiceAboutMapper.ToDto(data));
        }

        public IDataResult<ServiceAboutDto> GetById(int id)
        {
            var data = _serviceAboutDal.GetById(id);
            return new SuccessDataResult<ServiceAboutDto>(ServiceAboutMapper.ToDto(data));
        }

        public IResult HardDelete(int id)
        {
            var data = GetById(id).Data;
            _serviceAboutDal.Delete(ServiceAboutMapper.ToModel(data));

            return new SuccessResult(UiMessages.SuccessDeletedMessage(data.Title));
        }

        public IResult Restore(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = 0;
            _serviceAboutDal.Update(ServiceAboutMapper.ToModel(data));
            return new SuccessResult();
        }

        public IResult SoftDelete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _serviceAboutDal.Update(ServiceAboutMapper.ToModel(data));

            return new SuccessResult(UiMessages.SuccessCopyTrashMessage(data.Title));
        }

        public IResult Update(ServiceAboutUpdateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors)
        {
            ServiceAbout model = ServiceAboutMapper.ToModel(dto);
            ServiceAbout existData = ServiceAboutMapper.ToModel(GetById(model.Id).Data);
            var validator = _validator.Validate(model);
            errors = validator.Errors;
            if (!validator.IsValid)
            {
                return new ErrorResult();
            }
            if (photoUrl is null)
                model.PhotoUrl = existData.PhotoUrl;
            else
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            model.UpdatedDate = DateTime.Now;
            _serviceAboutDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage(model.Title));

        }
    }
}
