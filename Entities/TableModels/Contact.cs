using Core.Entities.Abstract;

namespace Entities.TableModels
{
    public class Contact : BaseEntity
    {
        public string Name {  get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Comments {  get; set; }
        public bool IsAnswer { get; set; }
        public bool IsRead { get; set; }

        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }

    }
}
