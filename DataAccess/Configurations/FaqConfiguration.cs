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
    public class FaqConfiguration : IEntityTypeConfiguration<Faq>
    {
        public void Configure(EntityTypeBuilder<Faq> builder)
        {
            builder.ToTable("Faqs");

            builder.Property(x => x.Id)
                .UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);

            builder.Property(x => x.Question)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(x => x.Answer)
               .IsRequired()
               .HasMaxLength(2000);
        }
    }
}
