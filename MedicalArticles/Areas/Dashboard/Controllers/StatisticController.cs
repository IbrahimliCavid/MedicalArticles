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

    public class StatisticController : Controller
    {
        private readonly IStatisticService _statisticService;
        private readonly ILanguageService _languageService;
        public StatisticController(IStatisticService statisticService, ILanguageService languageService)
        {
            _statisticService = statisticService;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            var data = _statisticService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            return View();
        }

        [HttpPost]

        public IActionResult Create(StatisticCreateDto dto)
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            var result = _statisticService.Add(dto, out List<ValidationFailure> errors);
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

            var data = _statisticService.GetById(id).Data;
            return View(StatisticMapper.ToUpdateDto(data));
        }

        [HttpPost]

        public IActionResult Edit(StatisticUpdateDto dto)
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            var result = _statisticService.Update(dto, out List<ValidationFailure> errors);
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
        public IActionResult SoftDelete(int id)
        {
            var result = _statisticService.SoftDelete(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);

        }


        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var result = _statisticService.HardDelete(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);

        }

        [HttpPost]
        public IActionResult Restore(int id)
        {
            var result = _statisticService.Restore(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);
        }

        [HttpGet]
        public IActionResult Trash()
        {
            var data = _statisticService.GetAllDeleted().Data;
            return View(data);
        }
    }
}
