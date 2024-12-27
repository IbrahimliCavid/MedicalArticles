using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public IActionResult Index()
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
            var datas = _blogService.GetAllByLangauge(currentCulture).Data;
            return View(datas);
        }

        public IActionResult Details(int id) {

            var data = _blogService.GetById(id).Data;
            return View(data);
        }
    }
}
