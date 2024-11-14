using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    public class HomeController : Controller
    {
        [Area("Dashboard")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
