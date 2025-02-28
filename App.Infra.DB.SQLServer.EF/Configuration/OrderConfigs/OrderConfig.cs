using HomeService.Domain.Core.HomeService.OrderEntity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeService.Domain.Core.HomeService.OrderEntity.Enums;

namespace App.Infra.DB.SQLServer.EF.Configuration.OrderConfigs
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                   .IsRequired();

            builder.HasOne(x => x   .Customer)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Service)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.ServiceId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Expert)
                   .WithMany(x => x.AcceptedOffers)
                   .HasForeignKey(x => x.ExpertId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.HasData(new Order
            {
                Id = 1,
                CityId = 1,
                CustomerId = 1,
                DateFor = new DateTime(2025, 10, 2),
                Description = "کاغذ دیواری خانه رو عوض کنید",
                ServiceId = 1,
                Status = StatusEnum.WaitingForExperts,
                TimeCreated = new DateTime(2025, 10, 2),


            });
        }
    }
}
