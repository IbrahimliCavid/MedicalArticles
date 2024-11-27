using Business.Abstract;
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
            var data = _serviceService.GetServiceWithServiceCategoryId().Data;
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

    }
}
