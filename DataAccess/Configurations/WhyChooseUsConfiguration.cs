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
    public class WhyChooseUsConfiguration : IEntityTypeConfiguration<WhyChooseUs>
    {
        public void Configure(EntityTypeBuilder<WhyChooseUs> builder)
        {
            builder.ToTable("WhyChooseUses");

            builder.Property(x => x.Id)
                .UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);

            builder.Property(x => x.Header)
                .IsRequired()
                .HasMaxLength(3000);

            builder.Property(x => x.PhotoUrl)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
