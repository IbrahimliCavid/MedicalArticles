﻿using Business.Abstract;
using Business.BaseMessages;
using Business.Mapper;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SosialManager : ISosialService
    {
        private readonly ISosialDal _sosialDal;
        private readonly IValidator<Sosial> _validator;

        public SosialManager(ISosialDal sosialDal, IValidator<Sosial> validator)
        {
            _sosialDal = sosialDal;
            _validator = validator;
        }

        public IResult Add(SosialCreateDto dto)
        {
            Sosial model = SosialMapper.ToModel(dto);
            var validator = _validator.Validate(model);

            string errorMesage = string.Empty;
            foreach (var error in validator.Errors)
            {
                errorMesage = error.ErrorMessage;
            }

            if (!validator.IsValid)
                return new ErrorResult(errorMesage);
            _sosialDal.Add(model);
            return new SuccessResult(UiMessages.SuccessAddedMessage("Məlumat"));
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<SosialDto>> GetAll()
        {
            var data = _sosialDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<SosialDto>>(SosialMapper.ToDto(data));

        }

        public IDataResult<SosialDto> GetById(int id)
        {
            var data = _sosialDal.GetById(id);
            return new SuccessDataResult<SosialDto>(SosialMapper.ToDto(data));
        }

        public IResult Update(SosialUpdateDto dto)
        {
            var model = SosialMapper.ToModel(dto);
            model.UpdatedDate = DateTime.Now;
            _sosialDal.Update(model);
            return new SuccessResult(UiMessages.SuccessUpdatedMessage("Məlumat"));
        }
    }
}
