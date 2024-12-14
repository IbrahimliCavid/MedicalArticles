using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
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

        [HttpGet]
        public IActionResult Index()
        {
             var currentCulture = Thread.CurrentThread.CurrentCulture.Name;

            var adressData = _adressService.GetAllByLanguage(currentCulture).Data;
            ContactViewModel viewModels = new ContactViewModel()
            {
                Contact = new ContactCreateDto(),
                Adresses = adressData
            };
            return View(viewModels);
        }

        [HttpPost]
        public IActionResult SendMessage(ContactCreateDto dto) 
        {
            var result = _contactService.Add(dto);
            if (!result.IsSuccess)
            {
                return Json(new { isSuccess = false });
            }
            return Json(new { isSuccess = true });
        }
    }
}
