using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using MedicalArticles.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ServiceAboutController : Controller
    {
        private readonly IServiceAboutService _serviceAboutService;
        private readonly IWebHostEnvironment _webEnv;
        private readonly ILanguageService _languageService;

        public ServiceAboutController(IServiceAboutService serviceAboutService, IWebHostEnvironment webEnv, ILanguageService languageService)
        {
            _serviceAboutService = serviceAboutService;
            _webEnv = webEnv;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            var data = _serviceAboutService.GetAll().Data;
            ViewBag.ShowButton = data.Count() == 0;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            return View();
        }

        [HttpPost]
        public IActionResult Create(ServiceAboutCreateDto dto, IFormFile photoUrl)
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            var result = _serviceAboutService.Add(dto, photoUrl, _webEnv.WebRootPath);
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
            ViewData["Languages"] = _languageService.GetAll().Data;

            var data = _serviceAboutService.GetById(id).Data;
            var model = ServiceAboutMapper.ToModel(data);
            return View(ServiceAboutMapper.ToUpdateDto(model));
        }

        [HttpPost]
        public IActionResult Edit(ServiceAboutUpdateDto dto, IFormFile photoUrl)
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            var result = _serviceAboutService.Update(dto, photoUrl, _webEnv.WebRootPath);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }

            return RedirectToAction("Index");
        }
    }
}
