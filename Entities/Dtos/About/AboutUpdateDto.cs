using Entities.TableModels;

namespace Entities.Dtos
{
    public class AboutUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }

        public static About ToAbout(AboutUpdateDto dto)
        {
            About about = new About()
            {
                Id  = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                PhotoUrl = dto.PhotoUrl,
            };
            return about;
        }
    }
}
