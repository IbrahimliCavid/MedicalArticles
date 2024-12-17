﻿using Business.Abstract;
using Business.BaseMessages;
using Business.Mapper;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using FluentValidation;
using FluentValidation.Results;

namespace Business.Concrete
{
    public class AdressManager : IAdressService
    {
        private readonly IAdressDal _adressDal;
        private readonly IValidator<Adress> _validator;

        public AdressManager(IAdressDal adressDal, IValidator<Adress> validator)
        {
            _adressDal = adressDal;
            _validator = validator;
        }

        public IResult Add(AdressCreateDto dto, out List<ValidationFailure> errors)
        {
            Adress model = AdressCreateDto.ToAdress(dto);
            var validator = _validator.Validate(model);
            errors = validator.Errors;

            if(!validator.IsValid) 
                return new ErrorResult();

            _adressDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(model.Email));
        }

        public IDataResult<List<AdressDto>> GetAll()
        {

            var data = _adressDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<AdressDto>>(AdressMapper.ToDto(data));
        } 
        public IDataResult<List<AdressDto>> GetAllByLanguage(string culture)
        {

            var data = _adressDal.GetAllByLanguage(culture);
            return new SuccessDataResult<List<AdressDto>>(AdressMapper.ToDto(data));
        }

        public IDataResult<List<Adress>> GetAllDeleted()
        {
            return new SuccessDataResult<List<Adress>>(_adressDal.GetAll(x => x.Deleted != 0));
        }

        public IDataResult<Adress> GetById(int id)
        {
           return new SuccessDataResult<Adress>(_adressDal.GetById(id));
        }

        public IResult HardDelete(int id)
        {
            Adress model = _adressDal.GetById(id);
            _adressDal.Delete(model);

            return new SuccessResult(UiMessages.SuccessDeletedMessage(model.Email));
        }

        public IResult SoftDelete(int id)
        {
            Adress model = _adressDal.GetById(id);
            model.Deleted = id;
            _adressDal.Update(model);

            return new SuccessResult(UiMessages.SuccessCopyTrashMessage(model.Email));
        }

        public IResult Update(AdressUpdateDto dto, out List<ValidationFailure> errors)
        {
            Adress model = AdressUpdateDto.ToAdress(dto);
            Adress existData = GetById(model.Id).Data;
            var validator = _validator.Validate(model);
            errors = validator.Errors;
            if (!validator.IsValid)
                return new ErrorResult();

            model.UpdatedDate = DateTime.Now;
            _adressDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage(existData.Email));
        }
    }
}
