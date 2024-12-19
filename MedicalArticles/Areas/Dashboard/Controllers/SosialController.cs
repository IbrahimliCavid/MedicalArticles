using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]

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
          var result = _sosialService.Add(dto, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                ModelState.Clear();
                foreach (var error in errors)
                {
                    ModelState.AddModelError($"{error.PropertyName}", error.ErrorMessage);
                }
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
            var result = _sosialService.Update(dto, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                ModelState.Clear();
                foreach (var error in errors)
                {
                    ModelState.AddModelError($"{error.PropertyName}", error.ErrorMessage);
                }
                return View(dto);
            }

            return RedirectToAction("Index");
        }
    }
}
