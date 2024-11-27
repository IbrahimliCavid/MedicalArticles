using Entities.TableModels;

namespace Entities.Dtos
{
    public class SlideCreateDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string PhotoUrl { get; set; }
        public int Deleted {  get; set; }

        public static Slide ToSlide(SlideCreateDto dto)
        {
            return new Slide
            {
                Title = dto.Title,
                Content = dto.Content,
                PhotoUrl = dto.PhotoUrl,
                Deleted = dto.Deleted,
            };
        }
    }
}
