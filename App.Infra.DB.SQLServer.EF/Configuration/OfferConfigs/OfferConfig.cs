using HomeService.Domain.Core.HomeService.OfferEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DB.SQLServer.EF.Configuration.OfferConfigs
{
    public class OfferConfig: IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Price)
                   .HasColumnType("decimal(18, 2)");

            builder.HasOne(x => x.Order)
                   .WithMany(x=>x.Offers)
                   .HasForeignKey(x => x.OrderId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Expert)
                   .WithMany(x => x.offers)
                   .HasForeignKey(x => x.ExpertId)
                   .OnDelete(DeleteBehavior.NoAction);


        }
    }
}
