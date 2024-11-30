using Business.Abstract;
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
    public class HealthTipItemManager : IHealthTipItemService
    {
        private readonly IHealthTipItemDal _healthTipItemDal;
        private readonly IValidator<HealthTipItem> _validator;

        public HealthTipItemManager(IHealthTipItemDal healthTipItemDal, IValidator<HealthTipItem> validator)
        {
            _healthTipItemDal = healthTipItemDal;
            _validator = validator;
        }

        public IResult Add(HealthTipItemCreateDto dto)
        {
            var model = HealthTipItemMapper.ToModel(dto);
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

            _healthTipItemDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage("Sual"));
        }
        public IResult Update(HealthTipItemUpdateDto dto)
        {
            var model = HealthTipItemMapper.ToModel(dto);
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

            _healthTipItemDal.Update(model);
            return new SuccessResult(UiMessages.SuccessUpdatedMessage("Sual"));
        }

        public IResult SoftDelete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            var model = HealthTipItemMapper.ToModel(data);
            _healthTipItemDal.Update(model);
            return new SuccessResult(UiMessages.SuccessDeletedMessage("Sual"));
        }
        public IResult HardDelete(int id)
        {
            var data = GetById(id).Data;
            var model = HealthTipItemMapper.ToModel(data);
            _healthTipItemDal.Delete(model);
            return new SuccessResult(UiMessages.SuccessDeletedMessage("Sual"));
        }


        public IDataResult<List<HealthTipItemDto>> GetAll()
        {
            var models = _healthTipItemDal.GetAllJoin();

            return new SuccessDataResult<List<HealthTipItemDto>>(models);
        }

        public IDataResult<List<HealthTipItemDto>> GetAllDeleted()
        {
            var models = _healthTipItemDal.GetDeleteAllJoin();

            return new SuccessDataResult<List<HealthTipItemDto>>(models);
        }

        public IDataResult<HealthTipItemDto> GetById(int id)
        {
            var model = _healthTipItemDal.GetById(id);

            return new SuccessDataResult<HealthTipItemDto>(HealthTipItemMapper.ToDto(model));
        }

        public IResult Restore(int id)
        {
            var data = _healthTipItemDal.GetById(id);
            data.Deleted = 0;
            _healthTipItemDal.Update(data);
            return new SuccessResult();
        }
    }
}
