using Business.Abstract;
using Business.Mapper;
using Core.Results.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ServiceController : Controller
    {
        private readonly IServiceService  _serviceService;
        private readonly ICategoryService _categoryService;
        private readonly IWebHostEnvironment _webEnv;

        public ServiceController(IServiceService serviceService, ICategoryService categoryService, IWebHostEnvironment webEnv)
        {
            _serviceService = serviceService;
            _categoryService = categoryService;
            _webEnv = webEnv;
        }

        public IActionResult Index()
        {
            var data = _serviceService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            ViewData["Categories"] = _categoryService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ServiceCreateDto dto, IFormFile photoUrl)
        {
            var result = _serviceService.Add(dto, photoUrl, _webEnv.WebRootPath);

            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddModelError($"", result.Message);
                ViewData["Categories"] = _categoryService.GetAll().Data;
                return View(dto);
            }
            return RedirectToAction("Index");

        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Categories"] = _categoryService.GetAll().Data;
            var data = _serviceService.GetById(id).Data;
            return View(ServiceMapper.ToUpdateDto(ServiceMapper.ToModel(data)));
        }

        [HttpPost]
        public IActionResult Edit(ServiceUpdateDto dto, IFormFile photoUrl)
        {
            var result = _serviceService.Update(dto, photoUrl, _webEnv.WebRootPath);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError($"", result.Message);
                ViewData["Categories"] = _categoryService.GetAll().Data;
                return View(dto);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult SoftDelete(int id)
        {
            var result = _serviceService.SoftDelete(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);

        }


        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var result = _serviceService.HardDelete(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);

        }

        [HttpPost]
        public IActionResult Restore(int id)
        {
            var result = _serviceService.Restore(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);
        }

        [HttpGet]
        public IActionResult Trash()
        {
            var data = _serviceService.GetAllDeleted().Data;
            return View(data);
        }
    }
}

