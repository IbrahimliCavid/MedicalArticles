using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class BlogCreateDto
    {
        public string Name { get; set; }
        public string? Surname { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public bool IsHomePage { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public int Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
