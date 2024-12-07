using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
