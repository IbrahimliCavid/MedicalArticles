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
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");

            builder.Property(x => x.Id)
                .UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);

            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(x => x.PhotoUrl)
                .IsRequired()
                .HasMaxLength(200);

            //Hasn't Relationship
        }
    }
}
