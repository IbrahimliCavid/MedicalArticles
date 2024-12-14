using Entities.Dtos;
using Entities.TableModels;
using Microsoft.IdentityModel.Tokens;

namespace MedicalArticles.ViewModels
{
    public class AboutViewModel
    {
        public List<TeamBoardDto> TeamBoards {  get; set; }
        public List<WhyChooseUsDto> WhyUs { get; set; }
        public List<ServiceDto> Services { get; set; }
    }
}
