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

        public HomeController(
            IServiceService serviceService,
            IServiceAboutItemService serviceAboutItemService,
            ITeamBoardService teamBoardService,
            ISlideService slideService,
            IContactService contactService,
            IHealthTipItemService healthTipItemService)
        {
            _serviceService = serviceService;
            _serviceAboutItemService = serviceAboutItemService;
            _teamBoardService = teamBoardService;
            _slideService = slideService;
            _contactService = contactService;
            _healthTipItemService = healthTipItemService;
        }

        public ActionResult Index()
        {
            var serviceData = _serviceService.GetAll().Data;
            var serviceItemData = _serviceAboutItemService.GetAll().Data;
            var teamData = _teamBoardService.GetAll().Data;
            var slideData = _slideService.GetAll().Data;
            var contactData = _contactService.GetAll().Data;
            var healthTipData = _healthTipItemService.GetAll().Data;

            HomeViewModel viewModel = new()
            {
                Services = serviceData,
                ServiceAboutItems = serviceItemData,
                TeamBoards = teamData,
                Slides = slideData,
                Contacts = contactData,
                HealthTipItems = healthTipData
            };

            return View(viewModel);
        }
    }
}
