using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using FluentValidation.Results;
using MedicalArticles.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class HealthTipController : Controller
    {
        private readonly IHealthTipService _healthTipService;
        private readonly IWebHostEnvironment _webEnv;
        private readonly ILanguageService _languageService;

        public HealthTipController(IHealthTipService healthTipService, IWebHostEnvironment webEnv, ILanguageService languageService)
        {
            _healthTipService = healthTipService;
            _webEnv = webEnv;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            var data = _healthTipService.GetAll().Data;
            ViewBag.ShowButton = data.Count < 3;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            return View();
        }

        [HttpPost]
        public IActionResult Create(HealthTipCreateDto dto, IFormFile photoUrl)
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            var result = _healthTipService.Add(dto, photoUrl, _webEnv.WebRootPath, out List<ValidationFailure> errors);
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
            ViewData["Languages"] = _languageService.GetAll().Data;

            var data = _healthTipService.GetById(id).Data;
            return View(HealthTipMapper.ToUpdateDto(data));
        }

        [HttpPost]

        public IActionResult Edit(HealthTipUpdateDto dto, IFormFile photoUrl)
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            var result = _healthTipService.Update(dto, photoUrl, _webEnv.WebRootPath, out List<ValidationFailure> errors);
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
