using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using MedicalArticles.Services;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AdressController : Controller
    {
        private readonly IAdressService _adressService;
        private readonly ILanguageService _languageService;
        public AdressController(IAdressService adressService, ILanguageService languageService)
        {
            _adressService = adressService;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            var data = _adressService.GetAll().Data;
            ViewBag.ShowButton = data.Count == 0;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create() {
            ViewData["Languages"] = _languageService.GetAll().Data;

            return View();
        }

        [HttpPost]
        public IActionResult Create(AdressCreateDto dto)
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            var result = _adressService.Add(dto);
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

            var data = _adressService.GetById(id).Data;
            return View(AdressMapper.ToUpdateDto(data));
        }

        [HttpPost]

        public IActionResult Edit(AdressUpdateDto dto)
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            var result = _adressService.Update(dto);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }
            return RedirectToAction("Index");
        }
    }
}
