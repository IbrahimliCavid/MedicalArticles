using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class TeamController : Controller
    {

        private readonly ITeamBoardService _teamService;

        public TeamController(ITeamBoardService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;

            var data = _teamService.GetAllByLangauge(currentCulture).Data;
            return View(data);
        }
    }
}
