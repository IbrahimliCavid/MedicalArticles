using Business.Abstract;
using MedicalArticles.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MedicalArticles.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IWhyChooseUsService _whyUsService;
        private readonly IFaqService _faqService;

        public ServiceController(IServiceService serviceService, IWhyChooseUsService whyUsService, IFaqService faqService)
        {
            _serviceService = serviceService;
            _whyUsService = whyUsService;
            _faqService = faqService;
        }

        public IActionResult Index()
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;

            var serviceData = _serviceService.GetAllByLanguage(currentCulture).Data;
            var whyUsData = _whyUsService.GetAllByLanguage(currentCulture).Data;    
            var faqData = _faqService.GetAllByLanguage(currentCulture).Data;
            ServiceViewModel viewModel = new()
            {
                Services = serviceData,
                WhyUs = whyUsData,
                Faqs = faqData
            };
            return View(viewModel);
        }
    }
}
