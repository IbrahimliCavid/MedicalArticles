using Core.Entities.Abstract;

namespace Entities.TableModels
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Services = new HashSet<Service>();
        }
        public string Name { get; set; }
        public string IconName { get; set; }
        public ICollection<Service> Services { get; set; }
    }
}
