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
        public DateTime CreatedDate { get; set; }
    }
}
