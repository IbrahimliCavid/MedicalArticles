﻿using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class SlideController : Controller
    {
        private readonly ISlideService _slideService;
        private readonly IWebHostEnvironment _webEnv;
        private readonly ILanguageService _languageService;

        public SlideController(ISlideService slideService, IWebHostEnvironment webEnv, ILanguageService languageService)
        {
            _slideService = slideService;
            _webEnv = webEnv;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            var data = _slideService.GetAll("ru-RU").Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Languages"] = _languageService.GetAll().Data;
            return View();
        }

        [HttpPost]

        public IActionResult Create(SlideCreateDto dto, IFormFile photoUrl)
        {
            ViewData["Languages"] = _languageService.GetAll().Data;
            var result = _slideService.Add(dto, photoUrl, _webEnv.WebRootPath);
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

            var data = _slideService.GetById(id).Data;
            var model = SlideMapper.ToModel(data);
            return View(SlideMapper.ToUpdateDto(model));
        }

        [HttpPost]

        public IActionResult Edit(SlideUpdateDto dto, IFormFile photoUrl)
        {
            ViewData["Languages"] = _languageService.GetAll().Data;

            var result = _slideService.Update(dto, photoUrl, _webEnv.WebRootPath);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SoftDelete(int id)
        {
            var result = _slideService.SoftDelete(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);

        }


        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var result = _slideService.HardDelete(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);

        }

        [HttpPost]
        public IActionResult Restore(int id)
        {
            var result = _slideService.Restore(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);
        }

        [HttpGet]
        public IActionResult Trash()
        {
            var data = _slideService.GetAllDeleted().Data;
            return View(data);
        }
    }
}
