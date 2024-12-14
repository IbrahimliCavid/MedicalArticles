using Entities.Dtos;
using Entities.TableModels;

namespace MedicalArticles.ViewModels
{
    public class ServiceViewModel
    {
        public List<ServiceDto> Services { get; set; }
        public List<WhyChooseUsDto> WhyUs { get; set; }
        public List<FaqDto> Faqs { get; set; }
    }
}
