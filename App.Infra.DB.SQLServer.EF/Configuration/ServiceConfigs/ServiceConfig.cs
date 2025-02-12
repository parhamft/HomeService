using HomeService.Domain.Core.HomeService.HomeServiceEntity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DB.SQLServer.EF.Configuration.ServiceConfigs
{
    public class ServiceConfig: IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(s => s.BasePrice)
                   .HasColumnType("decimal(18, 2)");

            builder.HasOne(s => s.SubCategory)
                   .WithMany(sc => sc.Services)
                   .HasForeignKey(s => s.SubCategoryId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
