using Core.Entities.Abstract;

namespace Entities.TableModels
{
    public class Sosial : BaseEntity
    {
        public string WhatsappUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string Telegram { get; set; }
        public string TwitterUrl { get; set; }
    }
}
