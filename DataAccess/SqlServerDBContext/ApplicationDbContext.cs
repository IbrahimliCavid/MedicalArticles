
using Entities.Concrete.TableModels.Membership;
using Entities.TableModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.SqlServerDBContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = DESKTOP-7K6OIQR;
                                         Initial Catalog = MedicalArticlesDB;
                                         Integrated Security= true;Encrypt = false;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<Sosial> Sosials { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
