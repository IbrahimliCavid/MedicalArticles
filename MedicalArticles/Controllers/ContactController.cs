using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
