using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]

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
            var model = ContactMapper.ToModel(data);
            var updateDto = ContactMapper.ToUpdateDto(model);
            updateDto.IsRead = true;
            _contactService.Update(updateDto);
          return View(updateDto);
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


        [HttpGet]
        public JsonResult GetUnreadMessage()
        {
            var count = _contactService.GetUnreadMessajeCount();
                return Json(count);
            
        }
    }
}
