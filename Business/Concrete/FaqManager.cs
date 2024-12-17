using Business.Abstract;
using Business.BaseMessages;
using Business.Mapper;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Dtos;
using Entities.TableModels;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Business.Concrete
{
    public class FaqManager : IFaqService
    {
        private readonly IFaqDal _faqDal;
        private readonly IValidator<Faq> _validator;

        public FaqManager(IFaqDal faqDal, IValidator<Faq> validator)
        {
            _faqDal = faqDal;
            _validator = validator;
        }

        public IResult Add(FaqCreateDto dto, out List<ValidationFailure> errors)
        {
            var model = FaqMapper.ToModel(dto);
            var validator = _validator.Validate(model);
            errors = validator.Errors;

            if (!validator.IsValid)
                return new ErrorResult();

            _faqDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage("Sual"));
        }
        public IResult Update(FaqUpdateDto dto, out List<ValidationFailure> errors)
        {
            var model = FaqMapper.ToModel(dto);
            model.UpdatedDate = DateTime.Now;
            var validator = _validator.Validate(model);

            errors = validator.Errors;

            if (!validator.IsValid)
                return new ErrorResult();

            _faqDal.Update(model);
            return new SuccessResult(UiMessages.SuccessUpdatedMessage("Sual"));
        }

        public IResult SoftDelete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            var model = FaqMapper.ToModel(data);
            _faqDal.Update(model);
            return new SuccessResult(UiMessages.SuccessDeletedMessage("Sual"));
        }
        public IResult HardDelete(int id)
        {
            var data = GetById(id).Data;
            var model = FaqMapper.ToModel(data);
            _faqDal.Delete(model);
            return new SuccessResult(UiMessages.SuccessDeletedMessage("Sual"));
        }


        public IDataResult<List<FaqDto>> GetAll()
        {
            var models = _faqDal.GetAll(x => x.Deleted == 0);

            return new SuccessDataResult<List<FaqDto>>(FaqMapper.ToDto(models));
        }
        public IDataResult<List<FaqDto>> GetAllByLanguage(string culture)
        {
            var models = _faqDal.GetAllByLanguage(culture);

            return new SuccessDataResult<List<FaqDto>>(FaqMapper.ToDto(models));
        }

        public IDataResult<List<FaqDto>> GetAllDeleted()
        {
            var models = _faqDal.GetAll(x => x.Deleted != 0);

            return new SuccessDataResult<List<FaqDto>>(FaqMapper.ToDto(models));
        }

        public IDataResult<FaqDto> GetById(int id)
        {
            var model = _faqDal.GetById(id);

            return new SuccessDataResult<FaqDto>(FaqMapper.ToDto(model));
        }

        public IResult Restore(int id)
        {
            var data = _faqDal.GetById(id);
            data.Deleted = 0;
            _faqDal.Update(data);
            return new SuccessResult();
        }
    }
}

