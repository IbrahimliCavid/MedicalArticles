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
                .HasMaxLength(13);

            builder.Property(x => x.Phone2)
           .HasMaxLength(13);


            builder.Property(x => x.Phone3)
           .HasMaxLength(13);


   
        }
    }
}
