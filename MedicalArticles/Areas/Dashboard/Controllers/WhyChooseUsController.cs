using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class WhyChooseUsController : Controller
    {
        private readonly IWhyChooseUsService _whyChooseUsService;
        private readonly IWebHostEnvironment _webEnv;

        public WhyChooseUsController(IWhyChooseUsService whyChooseUsService, IWebHostEnvironment webEnv)
        {
            _whyChooseUsService = whyChooseUsService;
            _webEnv = webEnv;
        }

        public IActionResult Index()
        {
            var data = _whyChooseUsService.GetAll().Data;
            ViewBag.ShowButton = data.Count == 0;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(WhyChooseUsCreateDto dto, IFormFile photoUrl)
        {
            var result = _whyChooseUsService.Add(dto, photoUrl, _webEnv.WebRootPath);
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
            var data = _whyChooseUsService.GetById(id).Data;
            return View(WhyChooseUsMapper.ToUpdateDto(WhyChooseUsMapper.ToModel(data)));
        }

        [HttpPost]

        public IActionResult Edit(WhyChooseUsUpdateDto dto, IFormFile photoUrl)
        {
            var result = _whyChooseUsService.Update(dto, photoUrl, _webEnv.WebRootPath);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message);
                return View(dto);
            }
            return RedirectToAction("Index");
        }
    }
}
