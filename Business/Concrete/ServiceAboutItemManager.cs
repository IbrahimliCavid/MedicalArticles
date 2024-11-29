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
    public class ServiceAboutItemManager : IServiceAboutItemService
    {
        private readonly IServiceAboutItemDal _serviceAboutItemDal;
        private readonly IValidator<ServiceAboutItem> _validator;

        public ServiceAboutItemManager(IServiceAboutItemDal serviceAboutItemDal, IValidator<ServiceAboutItem> validator)
        {
            _serviceAboutItemDal = serviceAboutItemDal;
            _validator = validator;
        }

        public IResult Add(ServiceAboutItemCreateDto dto)
        {
            var model = ServiceAboutItemMapper.ToModel(dto);
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

            _serviceAboutItemDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage("Sual"));
        }
        public IResult Update(ServiceAboutItemUpdateDto dto)
        {
            var model = ServiceAboutItemMapper.ToModel(dto);
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

            _serviceAboutItemDal.Update(model);
            return new SuccessResult(UiMessages.SuccessUpdatedMessage("Sual"));
        }

        public IResult SoftDelete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            var model = ServiceAboutItemMapper.ToModel(data);
            _serviceAboutItemDal.Update(model);
            return new SuccessResult(UiMessages.SuccessDeletedMessage("Sual"));
        }
        public IResult HardDelete(int id)
        {
            var data = GetById(id).Data;
            var model = ServiceAboutItemMapper.ToModel(data);
            _serviceAboutItemDal.Delete(model);
            return new SuccessResult(UiMessages.SuccessDeletedMessage("Sual"));
        }


        public IDataResult<List<ServiceAboutItemDto>> GetAll()
        {
            var models = _serviceAboutItemDal.GetAll(x => x.Deleted == 0);

            return new SuccessDataResult<List<ServiceAboutItemDto>>(ServiceAboutItemMapper.ToDto(models));
        }

        public IDataResult<List<ServiceAboutItemDto>> GetAllDeleted()
        {
            var models = _serviceAboutItemDal.GetAll(x => x.Deleted != 0);

            return new SuccessDataResult<List<ServiceAboutItemDto>>(ServiceAboutItemMapper.ToDto(models));
        }

        public IDataResult<ServiceAboutItemDto> GetById(int id)
        {
            var model = _serviceAboutItemDal.GetById(id);

            return new SuccessDataResult<ServiceAboutItemDto>(ServiceAboutItemMapper.ToDto(model));
        }

        public IResult Restore(int id)
        {
            var data = _serviceAboutItemDal.GetById(id);
            data.Deleted = 0;
            _serviceAboutItemDal.Update(data);
            return new SuccessResult();
        }
    }
}
