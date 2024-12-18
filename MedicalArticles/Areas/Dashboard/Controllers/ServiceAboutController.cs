using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using FluentValidation.Results;
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
        public IActionResult Create(ServiceAboutCreateDto dto, IFormFile photoUrl)
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            var result = _serviceAboutService.Add(dto, photoUrl, _webEnv.WebRootPath, out List<ValidationFailure> errors);
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

            var data = _serviceAboutService.GetById(id).Data;
            var model = ServiceAboutMapper.ToModel(data);
            return View(ServiceAboutMapper.ToUpdateDto(model));
        }

        [HttpPost]
        public IActionResult Edit(ServiceAboutUpdateDto dto, IFormFile photoUrl)
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            var result = _serviceAboutService.Update(dto, photoUrl, _webEnv.WebRootPath, out List<ValidationFailure> errors);
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
