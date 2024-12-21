using Core.DefaultValues;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blogs");
            builder.Property(x=>x.Id)
                .UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(x => x.Surname)
                .HasMaxLength(100);

            builder.Property(x => x.Title)
              .IsRequired()
              .HasMaxLength(500);

            builder.Property(x => x.Text)
              .IsRequired()
              .HasMaxLength(5000);

            builder.Property(x=>x.IsHomePage)
            .HasDefaultValue(false);
        }
    }
}
