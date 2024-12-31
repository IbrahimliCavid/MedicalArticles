using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class ContactDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Comments { get; set; }
        public bool IsAnswer {  get; set; }
        public bool IsRead {  get; set; }
        public int Deleted {  get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
