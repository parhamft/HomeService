using HomeService.Domain.Core.HomeService.CategoryEntity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DB.SQLServer.EF.Configuration.CategoryConfigs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasMaxLength(100)
                   .IsRequired();
            builder.HasData(
   new Category { Id = 1, Name = "تمیز کاری", ImagePath = "\\Images\\Category\\cleaning.jpg",TimeCreated = new DateTime(2025, 10, 2) },
      new Category { Id = 2, Name = "ساختمان", ImagePath = "\\Images\\Category\\building.jpg", TimeCreated = new DateTime(2025, 10, 2) },
      new Category { Id = 3, Name = "تعمیرات اشیا", ImagePath = "\\Images\\Category\\repair.jpg", TimeCreated = new DateTime(2025, 10, 2) },
      new Category { Id = 4, Name = "اسباب و حمل بار", ImagePath = "\\Images\\Category\\Moving.jpg", TimeCreated = new DateTime(2025, 10, 2) },
      new Category { Id = 5, Name = "خودرو", ImagePath = "\\Images\\Category\\Car.jpg", TimeCreated = new DateTime(2025, 10, 2) },
      new Category { Id = 6, Name = "سلامت و زیبایی", ImagePath = "\\Images\\Category\\Beauty.jpg", TimeCreated = new DateTime(2025, 10, 2) },
      new Category { Id = 7, Name = "سازمان ها مجتمع ها", ImagePath = "\\Images\\Category\\organiser.jpg", TimeCreated = new DateTime(2025, 10, 2) },
      new Category { Id = 8, Name = "سایر خدمات", ImagePath = "\\Images\\Category\\Other.jpg", TimeCreated = new DateTime(2025, 10, 2) }

);
        }
    }
}
