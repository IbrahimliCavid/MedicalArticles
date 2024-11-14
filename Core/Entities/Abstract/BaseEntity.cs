namespace Core.Entities.Abstract
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public int Deleted { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
    }
}
