using HomeService.Domain.Core.HomeService.CustomerEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.UserEntity.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
            builder.HasData(
            new Customer
            {
                Id = 1,
                Balance = 0,
                 
                FirstName = "Morad",
                LastName = "Shahram",
                Gender = GenderEnum.Male,
                ImagePath = "/Images/Users/matin.jpg",
                UserId = 3,
                TimeCreated = new DateTime(2025, 10, 2)
            });
        }
    } 
}
