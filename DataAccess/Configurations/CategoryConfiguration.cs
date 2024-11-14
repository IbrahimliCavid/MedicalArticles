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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.Property(x => x.Id).UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);
            builder.Property(x => x.IconName).IsRequired().HasMaxLength(200);
        }
    }
}
