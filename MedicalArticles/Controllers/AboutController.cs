using Business.Abstract;
using Entities.Dtos;
using MedicalArticles.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class AboutController : Controller
    {
        private readonly ITeamBoardService _teamService;
        private readonly IWhyChooseUsService _whyUsService;
        private readonly IWhyChooseUsItemService _whyUsItemService;
        private readonly IServiceService _serviceService;

        public AboutController(ITeamBoardService teamService, IWhyChooseUsService whyUsService, IWhyChooseUsItemService whyUsItemService, IServiceService serviceService)
        {
            _teamService = teamService;
            _whyUsService = whyUsService;
            _whyUsItemService = whyUsItemService;
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var teamData = _teamService.GetAll().Data;
            var whyUsItemData = _whyUsItemService.GetAll().Data;
            var serviceData = _serviceService.GetAll().Data;

            AboutViewModel viewModel = new()
            {
                TeamBoards = teamData,
                WhyUs = new WhyChooseUsDto(),
                WhyUsItems = whyUsItemData,
                Services = serviceData,
            };
            return View(viewModel);
        }
    }
}
