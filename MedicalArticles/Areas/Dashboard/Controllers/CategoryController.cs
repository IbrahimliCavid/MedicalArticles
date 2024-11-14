using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
        [Area("Dashboard")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var data = _categoryService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Create(CategoryCreateDto dto)
        {
            var result = _categoryService.Add(dto);
            if(!result.IsSuccess)
            {
                ModelState.AddModelError("Name", result.Message);
                return View(dto);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        
        public IActionResult Edit(int id)
        {
            var data = _categoryService.GetById(id).Data;
            return View(CategoryMapper.ToUpdateDto(data));
        }

        [HttpPost]

        public IActionResult Edit(CategoryUpdateDto dto)
        {
            var result = _categoryService.Update(dto);
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
            var result = _categoryService.SoftDelete(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);

        }


        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var result = _categoryService.HardDelete(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);

        }
    }
}
