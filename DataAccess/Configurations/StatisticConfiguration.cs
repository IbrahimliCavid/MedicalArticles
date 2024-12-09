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
    public class StatisticConfiguration : IEntityTypeConfiguration<Statistic>
    {
        public void Configure(EntityTypeBuilder<Statistic> builder)
        {
            builder.ToTable("Statistics");

            builder.Property(x=>x.Id)
                .UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Icon)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(x => new { x.Name, x.Deleted })
                .IsUnique();

            
        }
    }
}
