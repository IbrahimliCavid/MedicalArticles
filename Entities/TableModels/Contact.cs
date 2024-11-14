using Core.Entities.Abstract;

namespace Entities.TableModels
{
    public class Contact : BaseEntity
    {
        public string Name {  get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Message {  get; set; }
        public bool IsAnswer { get; set; }

    }
}
