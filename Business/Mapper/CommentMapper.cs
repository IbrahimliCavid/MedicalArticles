using Entities.Dtos;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapper
{
    public class CommentMapper
    {
        public static CommentDto ToDto(Comment model)
        {
            CommentDto dto = new CommentDto()
            {
                Id = model.Id,
                Name = model.Name,
                Content = model.Content,
                BlogId = model.BlogId,
                ParentCommentId = model.ParentCommentId,
                Replies = model.Replies,
                Deleted = model.Deleted,
                CreatedDate = model.CreatedDate,
            };

            return dto;
        }

        public static List<CommentDto> ToDto(List<Comment> models)
        {
            return models.Select(x => ToDto(x)).ToList();
        }

        public static Comment ToModel(CommentCreateDto createDto)
        {
            Comment model = new Comment()
            {
                Name = createDto.Name,
                Content = createDto.Content,
                BlogId = createDto.BlogId,
                ParentCommentId = createDto.ParentCommentId,
                Replies = createDto.Replies,
                Deleted = createDto.Deleted,
            };

            return model;
        }

        public static Comment ToModel(CommentDto dto)
        {
            Comment model = new Comment
            {
                Id= dto.Id,
                Name = dto.Name,
                Content = dto.Content,
                BlogId = dto.BlogId,
                ParentCommentId = dto.ParentCommentId,
                Replies = dto.Replies,
                Deleted = dto.Deleted,
                CreatedDate = dto.CreatedDate,
            };

            return model;
        }
    }
}
