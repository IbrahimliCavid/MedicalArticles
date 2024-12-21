using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.TableModels
{
    public class Blog : BaseEntity
    {
        public string Name {  get; set; }
        public string? Surname {  get; set; }
        public string Title {  get; set; }
        public string Text { get; set; }
        public bool IsHomePage {  get; set; }
        public int LanguageId {  get; set; }
        public virtual Language Language { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
