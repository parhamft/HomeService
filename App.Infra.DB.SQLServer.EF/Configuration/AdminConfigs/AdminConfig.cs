﻿using HomeService.Domain.Core.HomeService.AdminEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DB.SQLServer.EF.Configuration.AdminConfigs
{
    public class AdminConfig : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Balance)
                   .HasColumnType("decimal(18, 2)");


            builder.HasData(new Admin
            {
                Id = 1,
                FirstName = "reza",
                LastName = "ahmadi",
                Balance = 0,
                UserId = 1,
                TimeCreated = new DateTime(2025, 10, 2),
            });
        }
    }
}