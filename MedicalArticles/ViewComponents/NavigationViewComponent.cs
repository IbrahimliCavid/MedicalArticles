using Business.Abstract;
using MedicalArticles.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.ViewComponents
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly IAdressService _adressService;

        public NavigationViewComponent(IAdressService adressService)
        {
            _adressService = adressService;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            NavigationViewModel viewModel = new NavigationViewModel()
            {
                Adresses = _adressService.GetAll().Data,
            };
            return View(viewModel);
        }
    }
}
