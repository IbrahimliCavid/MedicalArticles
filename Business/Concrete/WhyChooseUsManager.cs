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
    public class WhyChooseUsManager : IWhyChooseUsService
    {
        private readonly IWhyChooseUsDal _whyChooseUsDal;
        private readonly IValidator<WhyChooseUs> _validator;
        private readonly IValidator<WhyChooseUsCreateDto> _validatorCreate;

        public WhyChooseUsManager(IValidator<WhyChooseUs> validator, IWhyChooseUsDal whyChooseUsDal, IValidator<WhyChooseUsCreateDto> validatorCreate)
        {
            _validator = validator;
            _whyChooseUsDal = whyChooseUsDal;
            _validatorCreate = validatorCreate;
        }

        public IResult Add(WhyChooseUsCreateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors)
        {
            var validator = _validatorCreate.Validate(dto);

            errors = validator.Errors;

            if (!validator.IsValid || photoUrl == null || photoUrl.Length <= 0)
            {
                errors.Add(new ValidationFailure("PhotoUrl", UiMessages.NotEmptyMessage("Foto")));
                return new ErrorResult();
            }
            WhyChooseUs model = WhyChooseUsMapper.ToModel(dto);
            model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);
            _whyChooseUsDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(""));
        }

        public IDataResult<List<WhyChooseUsDto>> GetAll()
        {
            var data = _whyChooseUsDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<WhyChooseUsDto>>(WhyChooseUsMapper.ToDto(data));
        }
        public IDataResult<List<WhyChooseUsDto>> GetAllByLanguage(string culture)
        {
            var data = _whyChooseUsDal.GetAllWhyUsWithItems(culture);
            return new SuccessDataResult<List<WhyChooseUsDto>>(data);
        }

        public IDataResult<List<WhyChooseUsDto>> GetAllDeleted()
        {
            var data = _whyChooseUsDal.GetAll(x => x.Deleted != 0);
            return new SuccessDataResult<List<WhyChooseUsDto>>(WhyChooseUsMapper.ToDto(data));
        }

        public IDataResult<WhyChooseUsDto> GetById(int id)
        {
            var data = _whyChooseUsDal.GetById(id);
            return new SuccessDataResult<WhyChooseUsDto>(WhyChooseUsMapper.ToDto(data));
        }

        public IResult HardDelete(int id)
        {
            var data = GetById(id).Data;
            _whyChooseUsDal.Delete(WhyChooseUsMapper.ToModel(data));

            return new SuccessResult(UiMessages.SuccessDeletedMessage(""));
        }

        public IResult Restore(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = 0;
            _whyChooseUsDal.Update(WhyChooseUsMapper.ToModel(data));
            return new SuccessResult();
        }

        public IResult SoftDelete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _whyChooseUsDal.Update(WhyChooseUsMapper.ToModel(data));

            return new SuccessResult(UiMessages.SuccessCopyTrashMessage(""));
        }

        public IResult Update(WhyChooseUsUpdateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors)
        {
            WhyChooseUs model = WhyChooseUsMapper.ToModel(dto);
            WhyChooseUs existData = WhyChooseUsMapper.ToModel(GetById(model.Id).Data);
            var validator = _validator.Validate(model);
            errors = validator.Errors;

            if (!validator.IsValid)
                return new ErrorResult();

            if (photoUrl is null)
                model.PhotoUrl = existData.PhotoUrl;
            else
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            _whyChooseUsDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage(""));

        }
    }
}
