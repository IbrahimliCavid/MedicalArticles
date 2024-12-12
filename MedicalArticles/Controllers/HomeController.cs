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
        private readonly IServiceAboutItemService _serviceAboutItemService;
        private readonly ITeamBoardService _teamBoardService;
        private readonly ISlideService _slideService;
        public readonly IContactService _contactService;
        public readonly IHealthTipItemService _healthTipItemService;
        private readonly IServiceAboutService _serviceAboutService;
        private readonly IHealthTipService _healthTipService;
        private readonly IStatisticService _statisticService;
        public readonly LanguageService _localization;


        public HomeController(
            IServiceService serviceService,
            IServiceAboutItemService serviceAboutItemService,
            ITeamBoardService teamBoardService,
            ISlideService slideService,
            IContactService contactService,
            IHealthTipItemService healthTipItemService,
            IServiceAboutService serviceAboutService,
            IHealthTipService healthTipService,
            LanguageService localization,
            IStatisticService statisticService)
        {
            _serviceService = serviceService;
            _serviceAboutItemService = serviceAboutItemService;
            _teamBoardService = teamBoardService;
            _slideService = slideService;
            _contactService = contactService;
            _healthTipItemService = healthTipItemService;
            _serviceAboutService = serviceAboutService;
            _healthTipService = healthTipService;
            _localization = localization;
            _statisticService = statisticService;
        }

        public IActionResult Index()
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;

            var serviceData = _serviceService.GetAll().Data;
            var serviceItemData = _serviceAboutItemService.GetAll().Data;
            var teamData = _teamBoardService.GetAllByLangauge(currentCulture).Data;
            var slideData = _slideService.GetAll(currentCulture).Data;
            var contactData = _contactService.GetAll().Data;
            var healthTipItemData = _healthTipItemService.GetAll().Data;
            var serviceAboutData = _serviceAboutService.GetAll().Data;
            var healthTipData = _healthTipService.GetAll().Data;
            var statisticData = _statisticService.GetAll().Data;

            ViewBag.Service = _localization.GetKey("Service").Value;

            HomeViewModel viewModel = new()
            {
                Services = serviceData,
                ServiceAboutItems = serviceItemData,
                TeamBoards = teamData,
                Slides = slideData,
                Contacts = contactData,
                HealthTipItems = healthTipItemData,
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
