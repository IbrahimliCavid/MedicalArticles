using Core.Entities.Abstract;

namespace Entities.TableModels
{
    public class Adress : BaseEntity
    {
        public string Location {  get; set; }
        public string Phone1 {  get; set; }
        public string Phone2 {  get; set; }
        public string Phone3 {  get; set; }
        public string Email {  get; set; }
    }
}
