using Entities.Concrete.TableModels.Membership;
using Entities.Dtos.Memberships;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace MedicalArticles.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDto dto) {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new();

                user = await _userManager.FindByEmailAsync(dto.Email);

                if (user == null)
                {
                    ViewBag.Message = "Email or password incorrect!!!";
                    goto end;
                }

                var result = await _signInManager.PasswordSignInAsync(user, dto.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new {area = "Dashboard"});
                }
                ViewBag.Message = "Email or password incorrect!!!";

            }
        end:
           
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}
