﻿using Business.Abstract;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HealthTipManager : IHealthTipService
    {
        private readonly IHealthTipDal _healthTipDal;
        private readonly IValidator<HealthTip> _validator;

        public HealthTipManager(IValidator<HealthTip> validator, IHealthTipDal healthTipDal)
        {
            _validator = validator;
            _healthTipDal = healthTipDal;
        }

        public IResult Add(HealthTipCreateDto dto, IFormFile photoUrl, string webRootPath)
        {
            HealthTip model = HealthTipMapper.ToModel(dto);
            var validator = _validator.Validate(model);
            model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            string errorMessage = "";

            foreach (var error in validator.Errors)
            {
                errorMessage = error.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }

            _healthTipDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(model.Title));
        }

        public IDataResult<List<HealthTipDto>> GetAll()
        {
            var data = _healthTipDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<HealthTipDto>>(HealthTipMapper.ToDto(data));
        }

        public IDataResult<List<HealthTipDto>> GetAllDeleted()
        {
            var data = _healthTipDal.GetAll(x => x.Deleted != 0);
            return new SuccessDataResult<List<HealthTipDto>>(HealthTipMapper.ToDto(data));
        }

        public IDataResult<HealthTip> GetById(int id)
        {
            return new SuccessDataResult<HealthTip>(_healthTipDal.GetById(id));
        }

        public IResult HardDelete(int id)
        {
            var data = GetById(id).Data;
            _healthTipDal.Delete(data);

            return new SuccessResult(UiMessages.SuccessDeletedMessage(data.Title));
        }

        public IResult Restore(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = 0;
            _healthTipDal.Update(data);
            return new SuccessResult();
        }

        public IResult SoftDelete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _healthTipDal.Update(data);

            return new SuccessResult(UiMessages.SuccessCopyTrashMessage(data.Title));
        }

        public IResult Update(HealthTipUpdateDto dto, IFormFile photoUrl, string webRootPath)
        {
            HealthTip model = HealthTipMapper.ToModel(dto);
            HealthTip existData = GetById(model.Id).Data;

            if (photoUrl is null)
                model.PhotoUrl = existData.PhotoUrl;
            else
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            model.UpdatedDate = DateTime.Now;
            _healthTipDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage(model.Title));

        }
    }
}
