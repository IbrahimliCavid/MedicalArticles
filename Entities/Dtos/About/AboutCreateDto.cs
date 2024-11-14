using Entities.TableModels;

namespace Entities.Dtos
{
    public class AboutCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }

        public static About ToAbout(AboutCreateDto dto)
        {
            About about = new About()
            {
                Title = dto.Title,
                Description = dto.Description,
                PhotoUrl = dto.PhotoUrl,
            };

            return about;
        }
    }
}
