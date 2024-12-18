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
    public class HealthTipConfiguration : IEntityTypeConfiguration<HealthTip>
    {
        public void Configure(EntityTypeBuilder<HealthTip> builder)
        {
     
        builder.ToTable("HealthTips");

            builder.Property(x => x.Id)
                .UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(x => x.Header)
                .IsRequired()
                .HasMaxLength(100);
            
            builder.Property(x => x.SubTitle)
                .IsRequired()
                .HasMaxLength(300);
            
            builder.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(3000);

            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(300);


            builder.Property(x => x.PhotoUrl)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasIndex(x => x.LanguageId)
               .IsUnique();

        }
    }
}
