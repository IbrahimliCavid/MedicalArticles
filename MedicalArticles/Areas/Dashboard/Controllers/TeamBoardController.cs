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
    public class TeamBoardController : Controller
    {

        private readonly ITeamBoardService _teamBoardService;
        private readonly IWebHostEnvironment _webEnv;
        private readonly ILanguageService _languageService;

        public TeamBoardController(ITeamBoardService teamBoardService, IWebHostEnvironment webEnv, ILanguageService languageService)
        {
            _teamBoardService = teamBoardService;
            _webEnv = webEnv;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            var data = _teamBoardService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            return View();
        }

        [HttpPost]

        public IActionResult Create(TeamBoardCreateDto dto, IFormFile photoUrl)
        {
            var result = _teamBoardService.Add(dto, photoUrl, _webEnv.WebRootPath, out List<ValidationFailure> errors);
            ViewData["Languages"] = _languageService.GetAll().Data;
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

            var data = _teamBoardService.GetById(id).Data;
            return View(TeamBoardMapper.ToUpdateDto(TeamBoardMapper.ToModel(data)));
        }

        [HttpPost]

        public IActionResult Edit(TeamBoardUpdateDto dto, IFormFile photoUrl)
        {
            var result = _teamBoardService.Update(dto, photoUrl, _webEnv.WebRootPath, out List<ValidationFailure> errors);
            ViewData["Languages"] = _languageService.GetAll().Data;

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
            var result = _teamBoardService.SoftDelete(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);

        }


        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var result = _teamBoardService.HardDelete(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);

        }

        [HttpPost]
        public IActionResult Restore(int id)
        {
            var result = _teamBoardService.Restore(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);
        }

        [HttpGet]
        public IActionResult Trash()
        {
            var data = _teamBoardService.GetAllDeleted().Data;
            return View(data);
        }
    }
}
