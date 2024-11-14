using Entities.TableModels;

namespace Entities.Dtos
{
    public class ServiceCreateDto
    {
        public string Description { get; set; }
        public string Title { get; set; }
        public string PhotoUrl { get; set; }

        public static Service ToService(ServiceCreateDto dto)
        {
            return new Service
            {
                Description = dto.Description,
                Title = dto.Title,
                PhotoUrl = dto.PhotoUrl,
            };
        }
    }
}
