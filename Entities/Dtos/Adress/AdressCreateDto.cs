using Entities.TableModels;

namespace Entities.Dtos
{
    public class AdressCreateDto
    {
        public string Location { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Email { get; set; }
        public int LanguageId { get; set; }

    }
}
