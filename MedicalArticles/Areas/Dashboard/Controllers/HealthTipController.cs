using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using MedicalArticles.Services;
using Microsoft.AspNetCore.Mvc;

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
            ViewBag.ShowButton = data.Count == 0;
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

            var result = _healthTipService.Add(dto, photoUrl, _webEnv.WebRootPath);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("Name", result.Message);
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

            var result = _healthTipService.Update(dto, photoUrl, _webEnv.WebRootPath);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }
            return RedirectToAction("Index");
        }
    }
}
