using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class BlogController : Controller
    {

        private readonly IBlogService _blogService;
        private readonly IWebHostEnvironment _webEnv;
        private readonly ILanguageService _languageService;

        public BlogController(IBlogService blogService, IWebHostEnvironment webEnv, ILanguageService languageService)
        {
            _blogService = blogService;
            _webEnv = webEnv;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            var data = _blogService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            return View();
        }

        [HttpPost]

        public IActionResult Create(BlogCreateDto dto, IFormFile photoUrl)
        {
            var result = _blogService.Add(dto, photoUrl, _webEnv.WebRootPath, out List<ValidationFailure> errors);
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

            var data = _blogService.GetById(id).Data;
            return View(BlogMapper.ToUpdateDto(BlogMapper.ToModel(data)));
        }

        [HttpPost]

        public IActionResult Edit(BlogUpdateDto dto, IFormFile photoUrl)
        {
            var result = _blogService.Update(dto, photoUrl, _webEnv.WebRootPath, out List<ValidationFailure> errors);
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
            var result = _blogService.SoftDelete(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);
        }


        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var result = _blogService.HardDelete(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);

        }

        [HttpPost]
        public IActionResult Restore(int id)
        {
            var result = _blogService.Restore(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);
        }

        [HttpGet]
        public IActionResult Trash()
        {
            var data = _blogService.GetAllDeleted().Data;
            return View(data);
        }
    }
}
