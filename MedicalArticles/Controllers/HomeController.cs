    using Business.Abstract;
using MedicalArticles.Models;
using MedicalArticles.Services;
using MedicalArticles.ViewModels;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MedicalArticles.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly ITeamBoardService _teamBoardService;
        private readonly ISlideService _slideService;
        public readonly IContactService _contactService;
        private readonly IServiceAboutService _serviceAboutService;
        private readonly IHealthTipService _healthTipService;
        private readonly IStatisticService _statisticService;
        public readonly LanguageService _localization;


        public HomeController(
            IServiceService serviceService,
            ITeamBoardService teamBoardService,
            ISlideService slideService,
            IContactService contactService,
            IServiceAboutService serviceAboutService,
            IHealthTipService healthTipService,
            LanguageService localization,
            IStatisticService statisticService)
        {
            _serviceService = serviceService;
            _teamBoardService = teamBoardService;
            _slideService = slideService;
            _contactService = contactService;
            _serviceAboutService = serviceAboutService;
            _healthTipService = healthTipService;
            _localization = localization;
            _statisticService = statisticService;
        }

        public IActionResult Index()
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;

            var serviceData = _serviceService.GetAllByLanguage(currentCulture).Data;
            var teamData = _teamBoardService.GetAllByLangauge(currentCulture).Data;
            var slideData = _slideService.GetAllByLanguage(currentCulture).Data;
            var contactData = _contactService.GetAll().Data;
            var serviceAboutData = _serviceAboutService.GetAllByLanguage(currentCulture).Data;
            var healthTipData = _healthTipService.GetAllByLanguage(currentCulture).Data;
            var statisticData = _statisticService.GetAllByLanguage(currentCulture).Data;

            ViewBag.Service = _localization.GetKey("Service").Value;

            HomeViewModel viewModel = new()
            {
                Services = serviceData,
                TeamBoards = teamData,
                Slides = slideData,
                Contacts = contactData,
                ServiceAbouts = serviceAboutData,
                HealthTips = healthTipData,
                Statistics = statisticData,
            };

            return View(viewModel);
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });
            return Redirect(Request.Headers["Referer"].ToString());
        }
    }
}
