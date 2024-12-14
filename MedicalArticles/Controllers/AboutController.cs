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
        private readonly IServiceService _serviceService;

        public AboutController(ITeamBoardService teamService, IWhyChooseUsService whyUsService, IServiceService serviceService)
        {
            _teamService = teamService;
            _whyUsService = whyUsService;
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;

            var teamData = _teamService.GetAllByLangauge(currentCulture).Data;
            var whyUsData = _whyUsService.GetAllByLanguage(currentCulture).Data;    
            var serviceData = _serviceService.GetAllByLanguage(currentCulture).Data;


            AboutViewModel viewModel = new()
            {
                TeamBoards = teamData,
                WhyUs =whyUsData,
                Services = serviceData,
            };
            return View(viewModel);
        }
    }
}
