using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class TeamBoardCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Profession { get; set; }
        public string PhotoUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? LinkedinUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public bool IsHomePage { get; set; }
        public int LanguageId { get; set; }

    }
}
