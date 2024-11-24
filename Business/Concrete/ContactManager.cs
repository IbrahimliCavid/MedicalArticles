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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        private readonly IValidator<Contact> _validator;

        public ContactManager(IContactDal contactDal, IValidator<Contact> validator)
        {
            _contactDal = contactDal;
            _validator = validator;
        }

        public IResult Add(ContactCreateDto dto)
        {
            var model = ContactMapper.ToModel(dto);
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

            _contactDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage("Kontakt"));
        }
        public IResult Update(ContactUpdateDto dto)
        {
            var model = ContactMapper.ToModel(dto);
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

            _contactDal.Update(model);
            return new SuccessResult(UiMessages.SuccessUpdatedMessage("Kontakt"));
        }

        public IResult SoftDelete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            var model = ContactMapper.ToModel(data);
            _contactDal.Update(model);
            return new SuccessResult(UiMessages.SuccessDeletedMessage("Kontakt"));
        }
        public IResult HardDelete(int id)
        {
            var data = GetById(id).Data;
            var model = ContactMapper.ToModel(data);
            _contactDal.Delete(model);
            return new SuccessResult(UiMessages.SuccessDeletedMessage("Kontakt"));
        }


        public IDataResult<List<ContactDto>> GetAll()
        {
            var models = _contactDal.GetAll(x => x.Deleted == 0);

            return new SuccessDataResult<List<ContactDto>>(ContactMapper.ToDto(models));
        }

        public int GetUnreadMessajeCount()
        {
            var data = _contactDal.GetAll(x => x.IsRead == false);
            return data.Count;
        }

        public IDataResult<List<ContactDto>> GetAllDeleted()
        {
            var models = _contactDal.GetAll(x => x.Deleted != 0);

            return new SuccessDataResult<List<ContactDto>>(ContactMapper.ToDto(models));
        }

        public IDataResult<ContactDto> GetById(int id)
        {
            var model = _contactDal.GetById(id);

            return new SuccessDataResult<ContactDto>(ContactMapper.ToDto(model));
        }

     
    }
}

