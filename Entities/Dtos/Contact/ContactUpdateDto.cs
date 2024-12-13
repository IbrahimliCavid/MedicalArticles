using Entities.TableModels;

namespace Entities.Dtos
{
    public class ContactUpdateDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Comments { get; set; }
        public bool IsAnswer { get; set; }
        public bool IsRead {  get; set; }
        public static Contact ToContact(ContactUpdateDto dto)
        {
            return new Contact
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                Phone = dto.Phone,
                Comments = dto.Comments,
                IsAnswer = dto.IsAnswer,
                IsRead = dto.IsRead,
            };
        }
    }
}
