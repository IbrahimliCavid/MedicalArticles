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
    public class AdressConfiguration : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder.ToTable("Adresses");

            builder.Property(x => x.Location)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Phone1)
                .IsRequired()
                .HasMaxLength(15);

            builder.Property(x => x.Phone2)
                .HasDefaultValue(null)
           .HasMaxLength(15);


            builder.Property(x => x.Phone3)
                .HasDefaultValue(null)
           .HasMaxLength(15);



        }
    }
}
