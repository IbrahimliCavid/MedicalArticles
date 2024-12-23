using Business.Abstract;
using Business.BaseMessages;
using Business.Mapper;
using Core.Extension;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blogDal;
        private readonly IValidator<Blog> _validator;

        public BlogManager(IValidator<Blog> validator, IBlogDal blogDal)
        {
            _validator = validator;
            _blogDal = blogDal;
        }

        public IResult Add(BlogCreateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors)
        {
            Blog model = BlogMapper.ToModel(dto);
            var validator = _validator.Validate(model);

            errors = validator.Errors;

            if (!validator.IsValid || photoUrl == null || photoUrl.Length <= 0)
            {
                errors.Add(new ValidationFailure("PhotoUrl", UiMessages.NotEmptyMessage("Foto")));
                return new ErrorResult();
            }


            model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);
            _blogDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(model.Name));
        }

        public IDataResult<List<BlogDto>> GetAll()
        {
            var data = _blogDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<BlogDto>>(BlogMapper.ToDto(data));
        }

        public IDataResult<List<BlogDto>> GetAllDeleted()
        {
            var data = _blogDal.GetAll(x => x.Deleted != 0);
            return new SuccessDataResult<List<BlogDto>>(BlogMapper.ToDto(data));
        }

        public IDataResult<List<BlogDto>> GetAllByLangauge(string culture)
        {
            var data = _blogDal.GetAllByLanguage(culture);
            return new SuccessDataResult<List<BlogDto>>(BlogMapper.ToDto(data));
        }

        public IDataResult<BlogDto> GetById(int id)
        {
            var data = _blogDal.GetById(id);
            return new SuccessDataResult<BlogDto>(BlogMapper.ToDto(data));
        }

        public IResult HardDelete(int id)
        {
            var data = GetById(id).Data;
            _blogDal.Delete(BlogMapper.ToModel(data));

            return new SuccessResult(UiMessages.SuccessDeletedMessage(data.Name));
        }

        public IResult Restore(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = 0;
            _blogDal.Update(BlogMapper.ToModel(data));
            return new SuccessResult();
        }

        public IResult SoftDelete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _blogDal.Update(BlogMapper.ToModel(data));

            return new SuccessResult(UiMessages.SuccessCopyTrashMessage(data.Name));
        }

        public IResult Update(BlogUpdateDto dto, IFormFile photoUrl, string webRootPath, out List<ValidationFailure> errors)
        {
            Blog model = BlogMapper.ToModel(dto);
            Blog existData = BlogMapper.ToModel(GetById(model.Id).Data);
            var validator = _validator.Validate(model);
            errors = validator.Errors;

            if (!validator.IsValid)
                return new ErrorResult();

            if (photoUrl is null)
                model.PhotoUrl = existData.PhotoUrl;
            else
                model.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            model.UpdatedDate = DateTime.Now;
            _blogDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage(model.Name));

        }
    }
}
