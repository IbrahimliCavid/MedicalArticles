using Entities.Dtos;
using Entities.TableModels;

namespace MedicalArticles.ViewModels
{
    public class HomeViewModel
    {
        public List<SlideDto> Slides { get; set; }
        public List<ContactDto> Contacts { get; set; }
        public List<ServiceDto> Services { get; set; }
        public List<ServiceAboutItemDto> ServiceAboutItems { get; set; }
        public List<HealthTipItemDto> HealthTipItems { get; set; }
        public List<TeamBoardDto> TeamBoards { get; set; }


    }
}
