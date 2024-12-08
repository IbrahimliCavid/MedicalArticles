using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
