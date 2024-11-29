using Business.Abstract;
using Business.BaseMessages;
using Business.Mapper;
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
    public class WhyChooseUsItemManager : IWhyChooseUsItemService 
    {

        private readonly IWhyChooseUsItemDal _whyChooseUsItemDal;
        private readonly IValidator<WhyChooseUsItem> _validator;

        public WhyChooseUsItemManager(IWhyChooseUsItemDal whyChooseUsItemDal, IValidator<WhyChooseUsItem> validator)
        {
            _whyChooseUsItemDal = whyChooseUsItemDal;
            _validator = validator;
        }

        public IResult Add(WhyChooseUsItemCraeteDto dto)
        {
            var model = WhyChooseUsItemMapper.ToModel(dto);
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

            _whyChooseUsItemDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage("Sual"));
        }
       
        public IResult Update(WhyChooseUsItemUpdateDto dto)
        {
            var model = WhyChooseUsItemMapper.ToModel(dto);
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

            _whyChooseUsItemDal.Update(model);
            return new SuccessResult(UiMessages.SuccessUpdatedMessage("Sual"));
        }

        public IResult SoftDelete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            var model = WhyChooseUsItemMapper.ToModel(data);
            _whyChooseUsItemDal.Update(model);
            return new SuccessResult(UiMessages.SuccessDeletedMessage("Sual"));
        }
        public IResult HardDelete(int id)
        {
            var data = GetById(id).Data;
            var model = WhyChooseUsItemMapper.ToModel(data);
            _whyChooseUsItemDal.Delete(model);
            return new SuccessResult(UiMessages.SuccessDeletedMessage("Sual"));
        }


        public IDataResult<List<WhyChooseUsItemDto>> GetAll()
        {
            var models = _whyChooseUsItemDal.GetAll(x => x.Deleted == 0);

            return new SuccessDataResult<List<WhyChooseUsItemDto>>(WhyChooseUsItemMapper.ToDto(models));
        }

        public IDataResult<List<WhyChooseUsItemDto>> GetAllDeleted()
        {
            var models = _whyChooseUsItemDal.GetAll(x => x.Deleted != 0);

            return new SuccessDataResult<List<WhyChooseUsItemDto>>(WhyChooseUsItemMapper.ToDto(models));
        }

        public IDataResult<WhyChooseUsItemDto> GetById(int id)
        {
            var model = _whyChooseUsItemDal.GetById(id);

            return new SuccessDataResult<WhyChooseUsItemDto>(WhyChooseUsItemMapper.ToDto(model));
        }

        public IResult Restore(int id)
        {
            var data = _whyChooseUsItemDal.GetById(id);
            data.Deleted = 0;
            _whyChooseUsItemDal.Update(data);
            return new SuccessResult();
        }

      
    }
}
