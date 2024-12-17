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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Concrete
{
    public class ServiceManager : IServiceService
    {
        private readonly IServiceDal _serviceDal;
        private readonly IValidator<Service> _validator;

        public ServiceManager(IServiceDal serviceDal, IValidator<Service> validator)
        {
            _serviceDal = serviceDal;
            _validator = validator;
        }

        public IResult Add(ServiceCreateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors)
        {
            Service model = ServiceCreateDto.ToService(dto);
            var validator = _validator.Validate(model);

            errors = validator.Errors;

            if (!validator.IsValid || photoUrl == null || photoUrl.Length <= 0)
            {
                errors.Add(new ValidationFailure("PhotoUrl", UiMessages.NotEmptyMessage("Foto")));
                return new ErrorResult();
            }

            model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);
            _serviceDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(model.Title));
        }


        public IDataResult<List<ServiceDto>> GetAll()
        {
            return new SuccessDataResult<List<ServiceDto>>(ServiceMapper.ToDto( _serviceDal.GetAll(x=>x.Deleted == 0)));
        } public IDataResult<List<ServiceDto>> GetAllByLanguage(string culture)
        {
            return new SuccessDataResult<List<ServiceDto>>(ServiceMapper.ToDto( _serviceDal.GetAllByLanguage(culture)));
        }

        public IDataResult<List<ServiceDto>> GetAllDeleted()
        {
            var data = _serviceDal.GetAll(x=>x.Deleted != 0);
            return new SuccessDataResult<List<ServiceDto>>(ServiceMapper.ToDto( data));
        }

        public IDataResult<ServiceDto> GetById(int id)
        {
            return new SuccessDataResult<ServiceDto>(ServiceMapper.ToDto(_serviceDal.GetById(id)));
        }

        public IResult HardDelete(int id)
        {
            var data = GetById(id).Data;
            var model = ServiceMapper.ToModel(data);    
            _serviceDal.Delete(model);

            return new SuccessResult(UiMessages.SuccessDeletedMessage(data.Title));
        }

        public IResult Restore(int id)
        {
            var data = GetById(id).Data;
            var model = ServiceMapper.ToModel(data);
            model.Deleted = 0;
            _serviceDal.Update(model);
            return new SuccessResult();
        }

        public IResult SoftDelete(int id)
        {
            var data = GetById(id).Data;
           var model = ServiceMapper.ToModel(data);
            model.Deleted = id;
            _serviceDal.Update(model);

            return new SuccessResult(UiMessages.SuccessCopyTrashMessage(data.Title));
        }

        public IResult Update(ServiceUpdateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors)
        {
            Service model = ServiceUpdateDto.ToService(dto);
            Service existData =ServiceMapper.ToModel(GetById(model.Id).Data);
            var validator = _validator.Validate(model);
            errors = validator.Errors;

            if (!validator.IsValid)
                return new ErrorResult();

            if (photoUrl is null)
                model.PhotoUrl = existData.PhotoUrl;
            else
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            model.UpdatedDate = DateTime.Now;
            _serviceDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage(model.Title));

        }

     
    }
}
