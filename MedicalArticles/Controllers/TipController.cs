using Business.Abstract;
using MedicalArticles.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class TipController : Controller
    {
        private readonly IHealthTipService _healthTipService;

        public TipController(IHealthTipService healthTipService)
        {
            _healthTipService = healthTipService;
        }

        public IActionResult Index()
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
            var tipData = _healthTipService.GetAllByLanguage(currentCulture).Data;
            TipViewModel viewModel = new()
            {
                HealthTips = tipData
            };
            return View(viewModel);
        }
    }
}
