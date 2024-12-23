using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class CommentCreateDto
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public int? ParentCommentId { get; set; }
        public int BlogId { get; set; }
        public int Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public Blog Blog { get; set; }
        public Comment ParentComment { get; set; }
        public ICollection<Comment> Replies { get; set; }
    }
}
