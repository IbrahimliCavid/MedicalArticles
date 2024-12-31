using Entities.TableModels;

namespace Entities.Dtos
{
    public class AdressUpdateDto
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Email { get; set; }
        public int LanguageId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
