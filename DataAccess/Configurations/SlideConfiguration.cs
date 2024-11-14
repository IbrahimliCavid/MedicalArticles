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
    public class SlideConfiguration : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Slides");

            builder.Property(x => x.Id)
                .UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);

            builder.Property(x=>x.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Content)
                .HasMaxLength(2000)
                .IsRequired();

            builder.Property(x => x.PhotoUrl)
                .IsRequired()
                .HasMaxLength(200);

        }
    }
}
