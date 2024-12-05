using Business.Abstract;
using MedicalArticles.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IAdressService _adressService;

        public ContactController(IContactService contactService, IAdressService adressService)
        {
            _contactService = contactService;
            _adressService = adressService;
        }

        public IActionResult Index()
        {
            var contactData = _contactService.GetAll().Data;
            var adressData = _adressService.GetAll().Data;
            ContactViewModel viewModels = new ContactViewModel()
            {
                Contacts = contactData,
                Adresses = adressData
            };
            return View(viewModels);
        }
    }
}
