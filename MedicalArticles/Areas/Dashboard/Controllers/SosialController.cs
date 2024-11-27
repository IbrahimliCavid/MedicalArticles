using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class SosialController : Controller
    {

        private readonly ISosialService _sosialService;

        public SosialController(ISosialService sosialService)
        {
            _sosialService = sosialService;
        }

        public IActionResult Index()
        {
            var data = _sosialService.GetAll().Data;
            ViewBag.ShowButton = data.Count() == 0;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create() 
        { 
           return View();
        }

        [HttpPost]
        public IActionResult Create(SosialCreateDto dto)
        {
          var result = _sosialService.Add(dto);
            if (!result.IsSuccess) 
            {
              ModelState.AddModelError("", result.Message);
                return View(dto);
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _sosialService.GetById(id).Data;
            var model = SosialMapper.ToModel(data);
            return View(SosialMapper.ToUpdateDto(model));
        }

        [HttpPost]
        public IActionResult Edit(SosialUpdateDto dto)
        {
            var result = _sosialService.Update(dto);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }

            return RedirectToAction("Index");
        }
    }
}
