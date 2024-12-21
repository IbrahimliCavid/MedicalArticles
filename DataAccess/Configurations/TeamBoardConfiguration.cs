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
    public class TeamBoardConfiguration : IEntityTypeConfiguration<TeamBoard>
    {
        public void Configure(EntityTypeBuilder<TeamBoard> builder)
        {
            
            builder.ToTable("TeamBoards");

            builder.Property(x => x.Id)
                .UseIdentityColumn(DefaultConstantValues.DEFAULT_PRIMARY_SEED_VALUE, 1);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Profession)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.FacebookUrl)
                .HasDefaultValue(null)
                .HasMaxLength(200);

            builder.Property(x => x.LinkedinUrl)
                .HasDefaultValue(null)
                .HasMaxLength(200);

            builder.Property(x => x.InstagramUrl)
                .HasDefaultValue(null)
                .HasMaxLength(200);


            builder.Property(x => x.PhotoUrl)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x=>x.IsHomePage) 
                .HasDefaultValue(false);
        }
    }
}
