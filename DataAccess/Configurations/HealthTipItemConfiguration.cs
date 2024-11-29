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
    public class HealthTipItemConfiguration : IEntityTypeConfiguration<HealthTipItem>
    {
        public void Configure(EntityTypeBuilder<HealthTipItem> builder)
        {
            builder.ToTable("HealthTipItems");

            builder.Property(x => x.Id)
                .UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);

            builder.Property(x => x.Text)
                .IsRequired()
                .HasMaxLength(300);

        }
    }
}
