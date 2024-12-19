using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using FluentValidation.Results;
using MedicalArticles.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]

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
            ViewBag.ShowButton = data.Count < 3;
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

            var result = _adressService.Add(dto, out List<ValidationFailure> errors);
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

            var data = _adressService.GetById(id).Data;
            return View(AdressMapper.ToUpdateDto(data));
        }

        [HttpPost]

        public IActionResult Edit(AdressUpdateDto dto)
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            var result = _adressService.Update(dto, out List<ValidationFailure> errors);
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
