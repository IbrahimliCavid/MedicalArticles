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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IResult Add(FaqCreateDto dto)
        {
            var model = FaqMapper.ToModel(dto);
            var validator = _validator.Validate(model);
            string errorMessage = "";

            foreach (var item in validator.Errors)
            {
                errorMessage = item.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }

            _faqDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage("Kontakt"));
        }
        public IResult Update(FaqUpdateDto dto)
        {
            var model = FaqMapper.ToModel(dto);
            model.UpdatedDate = DateTime.Now;
            var validator = _validator.Validate(model);

            string errorMessage = "";

            foreach (var item in validator.Errors)
            {
                errorMessage = item.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }

            _faqDal.Update(model);
            return new SuccessResult(UiMessages.SuccessUpdatedMessage("Kontakt"));
        }

        public IResult SoftDelete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            var model = FaqMapper.ToModel(data);
            _faqDal.Update(model);
            return new SuccessResult(UiMessages.SuccessDeletedMessage("Kontakt"));
        }
        public IResult HardDelete(int id)
        {
            var data = GetById(id).Data;
            var model = FaqMapper.ToModel(data);
            _faqDal.Delete(model);
            return new SuccessResult(UiMessages.SuccessDeletedMessage("Kontakt"));
        }


        public IDataResult<List<FaqDto>> GetAll()
        {
            var models = _faqDal.GetAll(x => x.Deleted == 0);

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


    }
}

