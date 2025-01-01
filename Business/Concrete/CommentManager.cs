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
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        private readonly IValidator<Comment> _validator;

        public CommentManager(ICommentDal commentDal, IValidator<Comment> validator)
        {
            _commentDal = commentDal;
            _validator = validator;
        }

        public IResult Add(CommentCreateDto dto, out List<ValidationFailure> errors)
        {
            Comment model = CommentMapper.ToModel(dto);
            var validator = _validator.Validate(model);
            errors = validator.Errors;

            if (!validator.IsValid)
                return new ErrorResult();

            
            _commentDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(""));
        }

        public IDataResult<List<CommentDto>> GetAll()
        {

            var data = _commentDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<CommentDto>>(CommentMapper.ToDto(data));
        }
       
      
        public IResult SoftDelete(int id)
        {
            Comment model = _commentDal.GetById(id);
            model.Deleted = id;
            _commentDal.Update(model);

            return new SuccessResult(UiMessages.SuccessCopyTrashMessage(""));
        }

    }
}
