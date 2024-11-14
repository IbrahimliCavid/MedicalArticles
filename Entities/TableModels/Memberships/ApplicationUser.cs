
using Microsoft.AspNetCore.Identity;

namespace Entities.Concrete.TableModels.Membership
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? ImageUrl { get; set; }
    }
}
