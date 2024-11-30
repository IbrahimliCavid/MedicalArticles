using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class HealthTipController : Controller
    {
        private readonly IHealthTipService _healthTipService;
        private readonly IWebHostEnvironment _webEnv;

        public HealthTipController(IHealthTipService healthTipService, IWebHostEnvironment webEnv)
        {
            _healthTipService = healthTipService;
            _webEnv = webEnv;
        }

        public IActionResult Index()
        {
            var data = _healthTipService.GetAll().Data;
            ViewBag.ShowButton = data.Count == 0;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HealthTipCreateDto dto, IFormFile photoUrl)
        {
            var result = _healthTipService.Add(dto, photoUrl, _webEnv.WebRootPath);
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
            var data = _healthTipService.GetById(id).Data;
            return View(HealthTipMapper.ToUpdateDto(data));
        }

        [HttpPost]

        public IActionResult Edit(HealthTipUpdateDto dto, IFormFile photoUrl)
        {
            var result = _healthTipService.Update(dto, photoUrl, _webEnv.WebRootPath);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }
            return RedirectToAction("Index");
        }
    }
}
