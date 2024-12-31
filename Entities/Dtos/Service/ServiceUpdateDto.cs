using Entities.TableModels;

namespace Entities.Dtos
{
    public class ServiceUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsHomePage { get; set; }
        public int LanguageId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
