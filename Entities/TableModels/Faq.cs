

using Core.Entities.Abstract;

namespace Entities.TableModels
{
    public class Faq : BaseEntity
    {
        public string Question {  get; set; }
        public string Answer {  get; set; }

    }
}
