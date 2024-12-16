using Entities.Dtos.Memberships;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginDto dto)
        {
        return View();
        }
    }
}
