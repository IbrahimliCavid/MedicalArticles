using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class SosialCreateDto
    {
        public string WhatsappUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string Telegram { get; set; }
        public string TwitterUrl { get; set; }

        public static Sosial ToSosial(SosialCreateDto dto)
        {
            Sosial sosial = new Sosial()
            {
                WhatsappUrl = dto.WhatsappUrl,
                FacebookUrl = dto.FacebookUrl,
                InstagramUrl = dto.InstagramUrl,
                Telegram = dto.TwitterUrl,
                TwitterUrl = dto.TwitterUrl,
            };
            return sosial;
        }
    }
}
