using HomeService.Domain.Core.HomeService.SubCategoryEntity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Infra.DB.SQLServer.EF.Configuration.SubCategoryConfigs
{
    public class SubCategoryConfig : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasOne(sc => sc.Category)
                   .WithMany(c => c.SubCategories)
                   .HasForeignKey(sc => sc.CategoryId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.HasData(
                new SubCategory { Id = 1, Name = "نظافت و پذیرایی", CategoryId = 1, ImagePath = "\\Images\\SubCategory\\1.jpg", TimeCreated = new DateTime(2025, 10, 2), },
                new SubCategory { Id = 2, Name = "شستشو", CategoryId = 1, ImagePath = "\\Images\\SubCategory\\2.jpg", TimeCreated = new DateTime(2025, 10, 2), },
                 new SubCategory { Id = 3, Name = "کارواش و دیتیلینگ", CategoryId = 1, ImagePath = "\\Images\\SubCategory\\3.jpg", TimeCreated = new DateTime(2025, 10, 2), },

               new SubCategory { Id = 4, Name = "سرمایش و گرمایش", CategoryId = 2, ImagePath = "\\Images\\SubCategory\\4.jpg", TimeCreated = new DateTime(2025, 10, 2), },
               new SubCategory { Id = 5, Name = "تعمیرات ساختمان", CategoryId = 2, ImagePath = "\\Images\\SubCategory\\5.jpg", TimeCreated = new DateTime(2025, 10, 2), },
                new SubCategory { Id = 6, Name = "لوله کشی", CategoryId = 2, ImagePath = "\\Images\\SubCategory\\6.jpg", TimeCreated = new DateTime(2025, 10, 2), },
                new SubCategory { Id = 7, Name = "سرمایش و گرمایش", CategoryId = 3, ImagePath = "\\Images\\SubCategory\\7.jpg", TimeCreated = new DateTime(2025, 10, 2), },
                new SubCategory { Id = 8, Name = "نصب و تعمیر لوازم خانگی", CategoryId = 3, ImagePath = "\\Images\\SubCategory\\8.jpg", TimeCreated = new DateTime(2025, 10, 2), },
                new SubCategory { Id = 9, Name = "خدمات کامپیوتریی", CategoryId = 3, ImagePath = "\\Images\\SubCategory\\9.jpg", TimeCreated = new DateTime(2025, 10, 2), },
new SubCategory { Id = 10, Name = "سباب‌کشی و حمل‌", CategoryId = 4, ImagePath = "\\Images\\SubCategory\\10.jpg", TimeCreated = new DateTime(2025, 10, 2), },
new SubCategory { Id = 11, Name = "خدمات و تعمیرات خودرو", CategoryId = 5, ImagePath = "\\Images\\SubCategory\\11.jpg", TimeCreated = new DateTime(2025, 10, 2), },
new SubCategory { Id = 12, Name = "زیبایی بانوان", CategoryId = 6, ImagePath = "\\Images\\SubCategory\\12.jpg", TimeCreated = new DateTime(2025, 10, 2), },
new SubCategory { Id = 13, Name = "پزشکی و پرستاری", CategoryId = 6, ImagePath = "\\Images\\SubCategory\\13.jpg", TimeCreated = new DateTime(2025, 10, 2), },
new SubCategory { Id = 14, Name = "خدمات شرکتی", CategoryId = 7, ImagePath = "\\Images\\SubCategory\\14.jpg", TimeCreated = new DateTime(2025, 10, 2), },
new SubCategory { Id = 15, Name = "تامین نیروی انسانی", CategoryId = 7, ImagePath = "\\Images\\SubCategory\\15.jpg", TimeCreated = new DateTime(2025, 10, 2), },
new SubCategory { Id = 16, Name = "خیاطی و تعمیرات لباس", CategoryId = 8, ImagePath = "\\Images\\SubCategory\\16.jpg", TimeCreated = new DateTime(2025, 10, 2), },
new SubCategory { Id = 17, Name = "مجالس و رویدادها", CategoryId = 8, ImagePath = "\\Images\\SubCategory\\17.jpg", TimeCreated = new DateTime(2025, 10, 2), }


                );
        }
    }
}
