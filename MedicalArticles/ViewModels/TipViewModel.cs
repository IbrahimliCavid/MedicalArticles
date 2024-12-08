using Entities.Dtos;
using Entities.TableModels;

namespace MedicalArticles.ViewModels
{
    public class TipViewModel
    {
        public List<HealthTipDto> HealthTips { get; set; }
        public List<HealthTipItemDto> HealthTipItems { get; set; }
    }
}
