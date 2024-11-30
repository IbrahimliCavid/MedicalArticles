using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("DashBoard")]
    public class WhyChooseUsItemController : Controller
    {
        private readonly IWhyChooseUsItemService _usItemService;
        private readonly IWhyChooseUsService _usService;

        public WhyChooseUsItemController(IWhyChooseUsItemService usItemService, IWhyChooseUsService usService)
        {
            _usItemService = usItemService;
            _usService = usService;
        }

        public IActionResult Index()
        {
            var data = _usItemService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["WhyUs"] = _usService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(WhyChooseUsItemCreateDto dto)
        {
            var result = _usItemService.Add(dto);

            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddModelError($"", result.Message);
                ViewData["WhyUs"] = _usService.GetAll().Data;
                return View(dto);
            }
            return RedirectToAction("Index");

        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["WhyUs"] = _usService.GetAll().Data;
            var data = _usItemService.GetById(id).Data;
            return View(WhyChooseUsItemMapper.ToUpdateDto(WhyChooseUsItemMapper.ToModel(data)));
        }

        [HttpPost]
        public IActionResult Edit(WhyChooseUsItemUpdateDto dto)
        {
            var result = _usItemService.Update(dto);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError($"", result.Message);
                ViewData["WhyUs"] = _usService.GetAll().Data;
                return View(dto);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult SoftDelete(int id)
        {
            var result = _usItemService.SoftDelete(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);

        }


        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var result = _usItemService.HardDelete(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);

        }

        [HttpPost]
        public IActionResult Restore(int id)
        {
            var result = _usItemService.Restore(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);
        }

        [HttpGet]
        public IActionResult Trash()
        {
            var data = _usItemService.GetAllDeleted().Data;
            return View(data);
        }
    }
}
