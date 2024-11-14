using Core.DefaultValues;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(x => x.Id)
               .UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Email)
                .HasMaxLength(100);

            builder.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(13);

            builder.Property(x => x.Message)
                .IsRequired()
                .HasMaxLength(4000);
        }
    }
}
