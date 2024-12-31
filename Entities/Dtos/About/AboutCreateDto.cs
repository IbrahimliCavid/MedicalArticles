using Entities.TableModels;

namespace Entities.Dtos
{
    public class AboutCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public int LanguageId {  get; set; }
    }
}
