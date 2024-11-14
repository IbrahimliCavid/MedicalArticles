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
    public class SosialConfiguration : IEntityTypeConfiguration<Sosial>
    {
        public void Configure(EntityTypeBuilder<Sosial> builder)
        {
            builder.Property(x => x.Id)
                .UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);

            builder.Property(x => x.WhatsappUrl)
                .HasMaxLength(500);

            builder.Property(x => x.FacebookUrl)
                .HasMaxLength(500);

            builder.Property(x => x.InstagramUrl)
                .HasMaxLength(500);

            builder.Property(x => x.Telegram)
                .HasMaxLength(500);

            builder.Property(x => x.TwitterUrl)
                .HasMaxLength(500);
        }
    }
}
