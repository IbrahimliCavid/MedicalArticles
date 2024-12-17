using Business.Abstract;
using Business.Mapper;
using DataAccess.Abstract;
using Entities.Dtos;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class HealthTipItemController : Controller
    {

        private readonly IHealthTipItemService _healthTipItemService;
        private readonly IHealthTipService _healthTipService;

        public HealthTipItemController(IHealthTipItemService healthTipItemService, IHealthTipService healthTipService)
        {
            _healthTipItemService = healthTipItemService;
            _healthTipService = healthTipService;
        }

        public IActionResult Index()
        {
            var data = _healthTipItemService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["HealthTip"] = _healthTipService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(HealthTipItemCreateDto dto)
        {
            var result = _healthTipItemService.Add(dto, out List<ValidationFailure> errors);

            if (!result.IsSuccess)
            {
                ModelState.Clear();
                foreach (var error in errors)
                {
                    ModelState.AddModelError($"{error.PropertyName}", error.ErrorMessage);
                }
               
                ViewData["HealthTip"] = _healthTipService.GetAll().Data;
                return View(dto);
            }
            return RedirectToAction("Index");

        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["HealthTip"] = _healthTipService.GetAll().Data;
            var data = _healthTipItemService.GetById(id).Data;
            return View(HealthTipItemMapper.ToUpdateDto(HealthTipItemMapper.ToModel(data)));
        }

        [HttpPost]
        public IActionResult Edit(HealthTipItemUpdateDto dto)
        {
            var result = _healthTipItemService.Update(dto, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                ModelState.Clear();
                foreach (var error in errors)
                {
                    ModelState.AddModelError($"{error.PropertyName}", error.ErrorMessage);
                }

                ViewData["HealthTip"] = _healthTipService.GetAll().Data;
                return View(dto);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult SoftDelete(int id)
        {
            var result = _healthTipItemService.SoftDelete(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);

        }


        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var result = _healthTipItemService.HardDelete(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);

        }

        [HttpPost]
        public IActionResult Restore(int id)
        {
            var result = _healthTipItemService.Restore(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);
        }

        [HttpGet]
        public IActionResult Trash()
        {
            var data = _healthTipItemService.GetAllDeleted().Data;
            return View(data);
        }
    }
}
