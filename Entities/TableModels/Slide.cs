using Core.Entities.Abstract;

namespace Entities.TableModels
{
    public class Slide : BaseEntity
    {
        public string Title {  get; set; }
        public string Content {  get; set; }
        public string PhotoUrl { get; set; }
    }
}
