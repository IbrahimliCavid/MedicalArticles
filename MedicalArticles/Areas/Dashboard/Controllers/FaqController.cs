using Business.Abstract;
using Business.Mapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class FaqController : Controller
    {

        private readonly IFaqService _faqService;

        public FaqController(IFaqService faqService)
        {
            _faqService = faqService;
        }

        public IActionResult Index()
        {
            var data = _faqService.GetAll().Data;
            return View(data);
        }

        [HttpGet]
        public IActionResult Create() 
        { 
           return View();
        }

        [HttpPost]
        public IActionResult Create(FaqCreateDto createDto) 
        {
          var result = _faqService.Add(createDto);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("Name", result.Message);
                return View(createDto);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id) 
        {
           var data = _faqService.GetById(id).Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(FaqUpdateDto dto) {
         
            var result = _faqService.Update(dto);
            if (!result.IsSuccess) {
            ModelState.AddModelError("", result.Message);
                return View(dto);
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult SoftDelete(int id) { 
        
           var result = _faqService.SoftDelete(id);
            if (result.IsSuccess) 
                return View("Index");
            return View(result);
        }

        [HttpPost]
        public IActionResult HardDelete(int id) 
        {
          var result = _faqService.HardDelete(id);
            if (result.IsSuccess)
                return View("Trash");
            return View(result);
        }

        [HttpGet]

        public IActionResult Trash() { 
        var data = _faqService.GetAllDeleted().Data;
            return View(data);
        }

        [HttpPost]
        public IActionResult Restore(int id) {
        var result = _faqService.Restore(id);
            if (result.IsSuccess)
                return View("Trash");
            return View(result);
        }
        

    }
}
