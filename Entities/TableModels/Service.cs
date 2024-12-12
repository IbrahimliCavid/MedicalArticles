using Core.Entities.Abstract;

namespace Entities.TableModels
{
    public class Service : BaseEntity
    {
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl {  get; set; }
        public virtual Category Category { get; set; }

        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }
    }
}
