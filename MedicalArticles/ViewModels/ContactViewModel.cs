using Entities.Dtos;

namespace MedicalArticles.ViewModels
{
    public class ContactViewModel
    {
        public List<ContactDto> Contacts { get; set; }
        public List<AdressDto> Adresses { get; set; }
    }
}
