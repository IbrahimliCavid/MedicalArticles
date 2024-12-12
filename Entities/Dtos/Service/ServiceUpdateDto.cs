using Entities.TableModels;

namespace Entities.Dtos
{
    public class ServiceUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public int CategoryId {  get; set; }
        public int LanguageId { get; set; }

        public static Service ToService(ServiceUpdateDto dto)
        {
            return new Service
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                PhotoUrl = dto.PhotoUrl,
                CategoryId = dto.CategoryId,
                LanguageId = dto.LanguageId,
            };
        }
    }
}
