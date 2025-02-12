using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DB.SQLServer.EF.Configuration.ExpertConfigs
{
    public class ExpertConfig : IEntityTypeConfiguration<Expert>
    {
        public void Configure(EntityTypeBuilder<Expert> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                   .HasMaxLength(50);

            builder.Property(x => x.LastName)
                   .HasMaxLength(50);

            builder.Property(x => x.Balance)
                   .HasColumnType("decimal(18, 2)");

            builder.Property(x => x.Rating)
                   .HasColumnType("decimal(3, 2)");

            builder.HasOne(x => x.User)
                   .WithOne(x => x.Expert)
                   .HasForeignKey<Expert>(x => x.UserId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.offers)
                   .WithOne(x => x.Expert)
                   .HasForeignKey(x => x.ExpertId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
