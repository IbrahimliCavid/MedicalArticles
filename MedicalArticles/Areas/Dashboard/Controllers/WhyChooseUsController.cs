using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using FluentValidation.Results;
using MedicalArticles.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]

    public class WhyChooseUsController : Controller
    {
        private readonly IWhyChooseUsService _whyChooseUsService;
        private readonly IWebHostEnvironment _webEnv;
        private readonly ILanguageService _languageService;

        public WhyChooseUsController(IWhyChooseUsService whyChooseUsService, IWebHostEnvironment webEnv, ILanguageService languageService)
        {
            _whyChooseUsService = whyChooseUsService;
            _webEnv = webEnv;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            var data = _whyChooseUsService.GetAll().Data;
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
        public IActionResult Create(WhyChooseUsCreateDto dto, IFormFile photoUrl)
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            var result = _whyChooseUsService.Add(dto, photoUrl, _webEnv.WebRootPath, out List<ValidationFailure> errors);
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

            var data = _whyChooseUsService.GetById(id).Data;
            return View(WhyChooseUsMapper.ToUpdateDto(WhyChooseUsMapper.ToModel(data)));
        }

        [HttpPost]

        public IActionResult Edit(WhyChooseUsUpdateDto dto, IFormFile photoUrl)
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            var result = _whyChooseUsService.Update(dto, photoUrl, _webEnv.WebRootPath, out List<ValidationFailure> errors);
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
