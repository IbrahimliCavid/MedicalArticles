﻿    using Business.Abstract;
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
    public class SlideManager : ISlideService
    {
        private readonly ISlideDal _slideDal;
        private readonly IValidator<Slide> _validator;

        public SlideManager(IValidator<Slide> validator, ISlideDal slideDal)
        {
            _validator = validator;
            _slideDal = slideDal;
        }

        public IResult Add(SlideCreateDto dto, IFormFile photoUrl, string webRootPath)
        {
            Slide model = SlideCreateDto.ToSlide(dto);
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

            _slideDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(model.Title));
        }

        public IDataResult<List<SlideDto>> GetAll(string lang)
        {
            var data = _slideDal.GetAllByLanguage(lang);
            return new SuccessDataResult<List<SlideDto>>(SlideMapper.ToDto(data));
        }

        public IDataResult<List<SlideDto>> GetAllDeleted()
        {
            var data = _slideDal.GetAll(x => x.Deleted != 0);
            return new SuccessDataResult<List<SlideDto>>(SlideMapper.ToDto(data));
        }

        public IDataResult<SlideDto> GetById(int id)
        {
            var data = _slideDal.GetById(id);
            return new SuccessDataResult<SlideDto>(SlideMapper.ToDto(data));
        }

        public IResult HardDelete(int id)
        {
            var data = GetById(id).Data;
            _slideDal.Delete(SlideMapper.ToModel(data));

            return new SuccessResult(UiMessages.SuccessDeletedMessage(data.Title));
        }

        public IResult Restore(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = 0;
            _slideDal.Update(SlideMapper.ToModel(data));
            return new SuccessResult();
        }

        public IResult SoftDelete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _slideDal.Update(SlideMapper.ToModel(data));

            return new SuccessResult(UiMessages.SuccessCopyTrashMessage(data.Title));
        }

        public IResult Update(SlideUpdateDto dto, IFormFile photoUrl, string webRootPath)
        {
            Slide model = SlideUpdateDto.ToSlide(dto);
            Slide existData = SlideMapper.ToModel( GetById(model.Id).Data);

            if (photoUrl is null)
                model.PhotoUrl = existData.PhotoUrl;
            else
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            model.UpdatedDate = DateTime.Now;
            _slideDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage(model.Title));

        }
    }
}

