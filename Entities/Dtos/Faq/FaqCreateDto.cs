using Entities.TableModels;

namespace Entities.Dtos
{
    public class FaqCreateDto
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public int LanguageId { get; set; }
    }
}