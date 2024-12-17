using Business.Abstract;
using Business.BaseMessages;
using Business.Mapper;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using FluentValidation;
using FluentValidation.Results;
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

        public IResult Add(SosialCreateDto dto, out List<ValidationFailure> errors)
        {
            Sosial model = SosialMapper.ToModel(dto);
            var validator = _validator.Validate(model);
            errors = validator.Errors;

            if (!validator.IsValid)
                return new ErrorResult();
            _sosialDal.Add(model);
            return new SuccessResult(UiMessages.SuccessAddedMessage("Məlumat"));
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

        public IResult Update(SosialUpdateDto dto, out List<ValidationFailure> errors)
        {
            var model = SosialMapper.ToModel(dto);
            var validator = _validator.Validate(model);
            errors = validator.Errors;

            if (!validator.IsValid)
                return new ErrorResult();
            model.UpdatedDate = DateTime.Now;
            _sosialDal.Update(model);
            return new SuccessResult(UiMessages.SuccessUpdatedMessage("Məlumat"));
        }
    }
}
