using Entities.TableModels;

namespace Entities.Dtos
{
    public class SlideUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string PhotoUrl { get; set; }
        public int Deleted {  get; set; }
        public int LanguageId { get; set; }


        public static Slide ToSlide(SlideUpdateDto dto)
        {
            return new Slide
            {
                Id = dto.Id,
                Title = dto.Title,
                Content = dto.Content,
                PhotoUrl = dto.PhotoUrl,
                Deleted = dto.Deleted,
            };
        }
    }
}
