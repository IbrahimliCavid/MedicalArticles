using Entities.TableModels;

namespace Entities.Dtos
{
    public class AdressCreateDto
    {
        public string Location { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Email { get; set; }

        public static Adress ToAdress(AdressCreateDto dto)
        {
            return new Adress
            {
                Location = dto.Location,
                Phone1 = dto.Phone1,
                Phone2 = dto.Phone2,
                Phone3 = dto.Phone3,
                Email = dto.Email
            };
        }
    }
}
