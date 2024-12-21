using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TableModels
{
    public class Comment : BaseEntity
    {
        public string Name { get; set; }
        public string Content {  get; set; }
        public int? ParentCommentId {  get; set; }
        public int BlogId {  get; set; }
        public Blog Blog { get; set; }
        public Comment ParentComment {  get; set; }
        public ICollection<Comment> Replies { get; set; }

    }
}
