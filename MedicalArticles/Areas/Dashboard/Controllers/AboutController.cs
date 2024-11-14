using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly IWebHostEnvironment _webEnv;

        public AboutController(IAboutService aboutService, IWebHostEnvironment webEnv)
        {
            _aboutService = aboutService;
            _webEnv = webEnv;
        }

        public IActionResult Index()
        {
            var data = _aboutService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(AboutCreateDto dto, IFormFile photoUrl)
        {
            var result = _aboutService.Add(dto, photoUrl, _webEnv.WebRootPath);
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
            var data = _aboutService.GetById(id).Data;
            return View(AboutMapper.ToUpdateDto(data));
        }

        [HttpPost]

        public IActionResult Edit(AboutUpdateDto dto, IFormFile photoUrl)
        {
            var result = _aboutService.Update(dto, photoUrl, _webEnv.WebRootPath);
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
            var result = _aboutService.SoftDelete(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);

        }


        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var result = _aboutService.HardDelete(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);

        }

        [HttpPost]
        public IActionResult Restore(int id) {
            var result = _aboutService.Restore(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);
        }

        [HttpGet]
        public IActionResult Trash()
        {
            var data = _aboutService.GetAllDeleted().Data;
            return View(data);
        }
    }
}

