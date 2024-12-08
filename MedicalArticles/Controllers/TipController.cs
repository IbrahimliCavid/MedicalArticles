using Business.Abstract;
using MedicalArticles.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class TipController : Controller
    {
        private readonly IHealthTipService _healthTipService;
        private readonly IHealthTipItemService _healthTipItemService;

        public TipController(IHealthTipService healthTipService, IHealthTipItemService healthTipItemService)
        {
            _healthTipService = healthTipService;
            _healthTipItemService = healthTipItemService;
        }

        public IActionResult Index()
        {
            var tipData = _healthTipService.GetAll().Data;
            var tipItemData = _healthTipItemService.GetAll().Data;
            TipViewModel viewModel = new()
            {
                HealthTipItems = tipItemData,
                HealthTips = tipData
            };
            return View(viewModel);
        }
    }
}
