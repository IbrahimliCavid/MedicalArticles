using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Areas.Dashboard.Controllers
{
    public class SosialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
