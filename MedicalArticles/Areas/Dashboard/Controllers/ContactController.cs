using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ContactController : Controller
    {

        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            var data = _contactService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var data = _contactService.GetById(id).Data;
          return View(ContactMapper.ToUpdateDto(ContactMapper.ToModel(data)));
        }

        [HttpPost]
        public IActionResult Edit(ContactUpdateDto dto) { 
          var result = _contactService.Update(dto);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }
            return RedirectToAction("Index");
        }
    }
}
