using Entities.Dtos;

namespace MedicalArticles.ViewModels
{
    public class ContactViewModel
    {
        public ContactCreateDto Contact { get; set; }
        public List<AdressDto> Adresses { get; set; }
    }
}
