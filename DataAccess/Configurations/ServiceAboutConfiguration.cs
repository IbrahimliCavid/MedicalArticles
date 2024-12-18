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
    public class ServiceAboutConfiguration : IEntityTypeConfiguration<ServiceAbout>
    {
        public void Configure(EntityTypeBuilder<ServiceAbout> builder)
        {
            builder.ToTable("ServiceAbouts");

            builder.Property(x => x.Id)
                .UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);

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
