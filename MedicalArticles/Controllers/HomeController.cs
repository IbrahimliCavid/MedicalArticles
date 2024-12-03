using Business.Abstract;
using MedicalArticles.Models;
using MedicalArticles.ViewModels;
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

        public HomeController(
            IServiceService serviceService,
            IServiceAboutItemService serviceAboutItemService,
            ITeamBoardService teamBoardService,
            ISlideService slideService,
            IContactService contactService,
            IHealthTipItemService healthTipItemService,
            IServiceAboutService serviceAboutService)
        {
            _serviceService = serviceService;
            _serviceAboutItemService = serviceAboutItemService;
            _teamBoardService = teamBoardService;
            _slideService = slideService;
            _contactService = contactService;
            _healthTipItemService = healthTipItemService;
            _serviceAboutService = serviceAboutService;
        }

        public ActionResult Index()
        {
            var serviceData = _serviceService.GetAll().Data;
            var serviceItemData = _serviceAboutItemService.GetAll().Data;
            var teamData = _teamBoardService.GetAll().Data;
            var slideData = _slideService.GetAll().Data;
            var contactData = _contactService.GetAll().Data;
            var healthTipData = _healthTipItemService.GetAll().Data;
            var serviceAboutData = _serviceAboutService.GetAll().Data;

            HomeViewModel viewModel = new()
            {
                Services = serviceData,
                ServiceAboutItems = serviceItemData,
                TeamBoards = teamData,
                Slides = slideData,
                Contacts = contactData,
                HealthTipItems = healthTipData,
                ServiceAbouts = serviceAboutData
            };

            return View(viewModel);
        }
    }
}
