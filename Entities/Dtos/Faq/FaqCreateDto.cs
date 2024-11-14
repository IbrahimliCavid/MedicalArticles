using Entities.TableModels;

namespace Entities.Dtos
{
    public class FaqCreateDto
    {
        public string Question { get; set; }
        public string Answer { get; set; }

        public static Faq ToFaq(FaqCreateDto dto)
        {
            return new Faq
            {
                Question = dto.Question,
                Answer = dto.Answer
            };
        }
    }
}