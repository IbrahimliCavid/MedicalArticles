using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class SosialUpdateDto
    {
        public int Id { get; set; }
        public string? WhatsappUrl { get; set; }
        public string? FacebookUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? Telegram { get; set; }
        public string? TwitterUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
