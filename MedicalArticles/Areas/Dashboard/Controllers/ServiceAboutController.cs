using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ServiceAboutController : Controller
    {
        private readonly IServiceAboutService _serviceAboutService;
        private readonly IWebHostEnvironment _webEnv;

        public ServiceAboutController(IServiceAboutService serviceAboutService, IWebHostEnvironment webEnv)
        {
            _serviceAboutService = serviceAboutService;
            _webEnv = webEnv;
        }

        public IActionResult Index()
        {
            var data = _serviceAboutService.GetAll().Data;
            ViewBag.ShowButton = data.Count() == 0;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ServiceAboutCreateDto dto, IFormFile photoUrl)
        {
            var result = _serviceAboutService.Add(dto, photoUrl, _webEnv.WebRootPath);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _serviceAboutService.GetById(id).Data;
            var model = ServiceAboutMapper.ToModel(data);
            return View(ServiceAboutMapper.ToUpdateDto(model));
        }

        [HttpPost]
        public IActionResult Edit(ServiceAboutUpdateDto dto, IFormFile photoUrl)
        {
            var result = _serviceAboutService.Update(dto, photoUrl, _webEnv.WebRootPath);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }

            return RedirectToAction("Index");
        }
    }
}
