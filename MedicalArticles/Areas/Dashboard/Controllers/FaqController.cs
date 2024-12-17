using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using FluentValidation.Results;
using MedicalArticles.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class FaqController : Controller
    {

        private readonly IFaqService _faqService;
        public readonly ILanguageService _languageService;

        public FaqController(IFaqService faqService, ILanguageService languageService)
        {
            _faqService = faqService;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            var data = _faqService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            return View();
        }

        [HttpPost]
        public IActionResult Create(FaqCreateDto createDto) 
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            var result = _faqService.Add(createDto, out List<ValidationFailure> errors);
            if (!result.IsSuccess)
            {
                ModelState.Clear();
                foreach (var error in errors)
                {
                    ModelState.AddModelError($"{error.PropertyName}", error.ErrorMessage);
                }
               
                return View(createDto);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            var data = _faqService.GetById(id).Data;
            return View(FaqMapper.ToUpdateDto(FaqMapper.ToModel(data)));
        }

        [HttpPost]
        public IActionResult Edit(FaqUpdateDto dto) {
            ViewData["Languages"] = _languageService.GetAll().Data;

            var result = _faqService.Update(dto, out List<ValidationFailure> errors); 
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

        [HttpPost]
        public IActionResult SoftDelete(int id) { 
        
           var result = _faqService.SoftDelete(id);
            if (result.IsSuccess) 
                return View("Index");
            return View(result);
        }

        [HttpPost]
        public IActionResult HardDelete(int id) 
        {
          var result = _faqService.HardDelete(id);
            if (result.IsSuccess)
                return View("Trash");
            return View(result);
        }

        [HttpGet]

        public IActionResult Trash() { 
        var data = _faqService.GetAllDeleted().Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Restore(int id) {
        var result = _faqService.Restore(id);
            if (result.IsSuccess)
                return View("Trash");
            return View(result);
        }
        

    }
}
