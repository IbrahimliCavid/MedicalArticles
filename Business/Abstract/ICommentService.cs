using Core.Results.Abstract;
using Entities.Dtos;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICommentService
    {
        IResult Add(CommentCreateDto dto, out List<ValidationFailure> errors);
        IDataResult<List<CommentDto>> GetAll();
        IResult SoftDelete (int id);
    }
}
