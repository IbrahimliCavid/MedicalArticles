using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class TipController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
