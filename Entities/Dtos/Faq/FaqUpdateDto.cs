using Entities.TableModels;

namespace Entities.Dtos
{
    public class FaqUpdateDto
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        public static Faq ToFaq(FaqUpdateDto dto)
        {
            return new Faq
            {
                Id = dto.Id,
                Question = dto.Question,
                Answer = dto.Answer,
            };
        }
    }
}
