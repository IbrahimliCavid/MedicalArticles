using Entities.TableModels;

namespace Entities.Dtos
{
    public class SlideCreateDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string PhotoUrl { get; set; }
        public int Deleted {  get; set; }
        public int LanguageId {  get; set; }
    }
}
