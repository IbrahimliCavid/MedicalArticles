using Entities.TableModels;

namespace Entities.Dtos
{
    public class ServiceCreateDto
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsHomePage {  get; set; }
        public int LanguageId { get; set; }
    }
}
