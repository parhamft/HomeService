﻿using HomeService.Domain.Core.HomeService.CustomerEntity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomeService.Domain.Core.HomeService.UserEntity.Enums;

namespace App.Infra.DB.SQLServer.EF.Configuration.CustomerConfigs
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName)
                   .HasMaxLength(50);

            builder.Property(x => x.LastName)
                   .HasMaxLength(50);

            builder.Property(x => x.Balance)
                   .HasColumnType("decimal(18, 2)");

            builder.HasOne(x => x.User)
                   .WithOne(x => x.Customer)
                   .HasForeignKey<Customer>(x => x.UserId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Orders)
                   .WithOne(x => x.Customer)
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.HasData(
                new Customer
                {
                    Id = 1,
                    Balance = 0,
                    FirstName = "Shahram",
                    LastName = "Moradi",
                    Gender = GenderEnum.Male,
                    ImagePath = "/Images/Users/matin.jpg",
                    UserId = 2,
                    TimeCreated = new DateTime(2025, 10, 2)

                }
                );
        }
    }
}
