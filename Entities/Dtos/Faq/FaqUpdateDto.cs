using Entities.TableModels;

namespace Entities.Dtos
{
    public class FaqUpdateDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int LanguageId { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
