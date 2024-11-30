using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class ServiceAboutItemController : Controller
    {

        private readonly IServiceAboutItemService _serviceAboutItemService;
        private readonly IServiceAboutService _serviceAboutService;

        public ServiceAboutItemController(IServiceAboutItemService serviceAboutItemService, IServiceAboutService serviceAboutService)
        {
            _serviceAboutItemService = serviceAboutItemService;
            _serviceAboutService = serviceAboutService;
        }

        public IActionResult Index()
        {
            var data = _serviceAboutItemService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ServiceAbout"] = _serviceAboutService.GetAll().Data;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ServiceAboutItemCreateDto dto)
        {
            var result = _serviceAboutItemService.Add(dto);

            if (!result.IsSuccess)
            {
                ModelState.Clear();
                ModelState.AddModelError($"", result.Message);
                ViewData["ServiceAbout"] = _serviceAboutService.GetAll().Data;
                return View(dto);
            }
            return RedirectToAction("Index");

        }



        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["ServiceAbout"] = _serviceAboutService.GetAll().Data;
            var data = _serviceAboutItemService.GetById(id).Data;
            return View(ServiceAboutItemMapper.ToUpdateDto(ServiceAboutItemMapper.ToModel(data)));
        }

        [HttpPost]
        public IActionResult Edit(ServiceAboutItemUpdateDto dto)
        {
            var result = _serviceAboutItemService.Update(dto);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError($"", result.Message);
                ViewData["ServiceAbout"] = _serviceAboutService.GetAll().Data;
                return View(dto);
            }
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult SoftDelete(int id)
        {
            var result = _serviceAboutItemService.SoftDelete(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);

        }


        [HttpPost]
        public IActionResult HardDelete(int id)
        {
            var result = _serviceAboutItemService.HardDelete(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);

        }

        [HttpPost]
        public IActionResult Restore(int id)
        {
            var result = _serviceAboutItemService.Restore(id);
            if (result.IsSuccess)
                return View(Index);
            return View(result);
        }

        [HttpGet]
        public IActionResult Trash()
        {
            var data = _serviceAboutItemService.GetAllDeleted().Data;
            return View(data);
        }
    }
}
