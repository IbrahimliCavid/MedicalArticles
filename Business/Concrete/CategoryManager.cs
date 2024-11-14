using Business.Abstract;
using Business.BaseMessages;
using Business.Mapper;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using FluentValidation;
using System.Security.Cryptography.X509Certificates;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IValidator<Category> _validator;

        public CategoryManager(ICategoryDal categoryDal, IValidator<Category> validator)
        {
            _categoryDal = categoryDal;
            _validator = validator;
        }

        public IResult Add(CategoryCreateDto dto)
        {
            var model = CategoryMapper.ToModel(dto);
            var validator= _validator.Validate(model);
            string errorMessage = "";

            foreach (var item in validator.Errors)
            {
                errorMessage = item.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }

            _categoryDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage("Kateqoriya"));
        }
        public IResult Update(CategoryUpdateDto dto)
        {
            var model = CategoryMapper.ToModel(dto);
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

            _categoryDal.Update(model);
            return new SuccessResult(UiMessages.SuccessUpdatedMessage("Kateqoriya"));
        }

        public IResult SoftDelete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            var model = CategoryMapper.ToModel(data);
            _categoryDal.Update(model);
            return new SuccessResult(UiMessages.SuccessDeletedMessage("Kateqoriya"));
        }
        public IResult HardDelete(int id)
        {
            var data = GetById(id).Data;
            var model = CategoryMapper.ToModel(data);
            _categoryDal.Delete(model);
            return new SuccessResult (UiMessages.SuccessDeletedMessage("Kateqoriya"));
        }


        public IDataResult<List<CategoryDto>> GetAll()
        {
            var models = _categoryDal.GetAll(x=>x.Deleted == 0);

            return new SuccessDataResult<List<CategoryDto>>(CategoryMapper.ToDto(models));
        }

        public IDataResult<List<CategoryDto>> GetAllDeleted()
        {
            var models = _categoryDal.GetAll(x => x.Deleted != 0);

            return new SuccessDataResult<List<CategoryDto>>(CategoryMapper.ToDto(models));
        }

        public IDataResult<CategoryDto> GetById(int id)
        {
            var model = _categoryDal.GetById(id);

            return new SuccessDataResult<CategoryDto>(CategoryMapper.ToDto(model));
        }

    }
}
