using HomeService.Domain.Core.HomeService.ImageEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DB.SQLServer.EF.Configuration
{
    public class ImageConfigs : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasOne(x=>x.Order)
                .WithMany(x=>x.Images)
                .HasForeignKey(x=>x.OrderId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasData(new Image
            {
                Id = 1,
                OrderId = 1,
                ImagePath = "Images/Orders/wall.jpg"
            });
                
        }
    }
}
