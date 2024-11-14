using Entities.TableModels;

namespace Entities.Dtos
{
    public class AdressUpdateDto
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Email { get; set; }

        public static Adress ToAdress(AdressUpdateDto dto)
        {
            Adress adress = new Adress()
            {
                Id = dto.Id,
                Email = dto.Email,
                Location = dto.Location,
                Phone1 = dto.Phone1,
                Phone2 = dto.Phone2,
                Phone3 = dto.Phone3,
            };
            return adress;
        }
    }
}
