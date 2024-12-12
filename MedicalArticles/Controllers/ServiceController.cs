using Business.Abstract;
using MedicalArticles.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IWhyChooseUsItemService _whyUsItemService;
        private readonly IWhyChooseUsService _whyUsService;
        private readonly IFaqService _faqService;

        public ServiceController(IServiceService serviceService, IWhyChooseUsItemService whyUsItemService, IWhyChooseUsService whyUsService, IFaqService faqService)
        {
            _serviceService = serviceService;
            _whyUsItemService = whyUsItemService;
            _whyUsService = whyUsService;
            _faqService = faqService;
        }

        public IActionResult Index()
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;

            var serviceData = _serviceService.GetAll().Data;
            var whyUsItemData = _whyUsItemService.GetAll().Data;
            var whyUsData = _whyUsService.GetAll().Data;    
            var faqData = _faqService.GetAllByLanguage(currentCulture).Data;
            ServiceViewModel viewModel = new()
            {
                Services = serviceData,
                WhyUs = whyUsData,
                WhyUsItems = whyUsItemData,
                Faqs = faqData
            };
            return View(viewModel);
        }
    }
}
