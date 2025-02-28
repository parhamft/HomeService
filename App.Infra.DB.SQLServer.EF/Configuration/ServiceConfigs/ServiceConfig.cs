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
            builder.HasData(
                new Service { Id = 1, BasePrice = 500, Name = "سرویس عادی نظافت", SubCategoryId = 1, ImagePath = "\\Images\\Services\\1.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 2, BasePrice = 500, Name = "سرویس ویژه نظافت", SubCategoryId = 1, ImagePath = "\\Images\\Services\\2.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 3, BasePrice = 500, Name = "قالیشویی", SubCategoryId = 2, ImagePath = "\\Images\\Services\\3.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 4, BasePrice = 500, Name = "خشکشویی", SubCategoryId = 2, ImagePath = "\\Images\\Services\\4.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 5, BasePrice = 500, Name = "سرامیک خودرو", SubCategoryId = 3, ImagePath = "\\Images\\Services\\5.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 6, BasePrice = 500, Name = "صفرشویی خودرو", SubCategoryId = 3, ImagePath = "\\Images\\Services\\6.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 7, BasePrice = 500, Name = "تعمیر و سرویس پکیج", SubCategoryId = 4, ImagePath = "\\Images\\Services\\7.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 8, BasePrice = 500, Name = "تعمیر و سرویس آبگرمکن<", SubCategoryId = 4, ImagePath = "\\Images\\Services\\8.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 9, BasePrice = 500, Name = "سنگ کاری", SubCategoryId = 5, ImagePath = "\\Images\\Services\\9.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 10, BasePrice = 500, Name = "نقاشی ساختمان", SubCategoryId = 5, ImagePath = "\\Images\\Services\\10.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 11, BasePrice = 500, Name = "نصب و تعمیر شیرآلات", SubCategoryId = 6, ImagePath = "\\Images\\Services\\11.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 12, BasePrice = 500, Name = "تخلیه چاه و لوله بازکنی", SubCategoryId = 6, ImagePath = "\\Images\\Services\\12.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 13, BasePrice = 500, Name = "تعمیر و سرویس پکیج", SubCategoryId = 7, ImagePath = "\\Images\\Services\\13.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 14, BasePrice = 500, Name = "تعمیر و سرویس آبگرمکن", SubCategoryId = 7, ImagePath = "\\Images\\Services\\14.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 15, BasePrice = 500, Name = "تعمیر کامپیوتر و لپ تاپ", SubCategoryId = 9, ImagePath = "\\Images\\Services\\15.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 16, BasePrice = 500, Name = "مودم و اینترنت", SubCategoryId = 9, ImagePath = "\\Images\\Services\\16.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 17, BasePrice = 500, Name = "نصب و تعمیر یخچال و فریزر", SubCategoryId = 8, ImagePath = "\\Images\\Services\\17.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 18, BasePrice = 500, Name = "نصب و تعمیر ماشین لباسشویی", SubCategoryId = 8, ImagePath = "\\Images\\Services\\18.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 19, BasePrice = 500, Name = "اسباب کشی با خاور و کامیون", SubCategoryId = 10, ImagePath = "\\Images\\Services\\19.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 20, BasePrice = 500, Name = "اسباب کشی با وانت و نیسان", SubCategoryId = 10, ImagePath = "\\Images\\Services\\20.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 21, BasePrice = 500, Name = "تعویض باتری خودرو", SubCategoryId = 11, ImagePath = "\\Images\\Services\\21.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 22, BasePrice = 500, Name = "باتری به باتری", SubCategoryId = 11, ImagePath = "\\Images\\Services\\22.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 23, BasePrice = 500, Name = "خدمات ناخن", SubCategoryId = 12, ImagePath = "\\Images\\Services\\23.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 24, BasePrice = 500, Name = "رنگ مو بانوان", SubCategoryId = 12, ImagePath = "\\Images\\Services\\24.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 25, BasePrice = 500, Name = "مراقبت و نگهداری", SubCategoryId = 10, ImagePath = "\\Images\\Services\\25.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 26, BasePrice = 500, Name = "پرستاری و تزریقات", SubCategoryId = 10, ImagePath = "\\Images\\Services\\26.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 27, BasePrice = 500, Name = "خدمات شرکتی (ویژه شرکت های کوچک و متوسط)", SubCategoryId = 14, ImagePath = "\\Images\\Services\\27.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 28, BasePrice = 500, Name = "پیشنهاد فروش خدمات آچاره به شرکت ها", SubCategoryId = 14, ImagePath = "\\Images\\Services\\28.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 29, BasePrice = 500, Name = "استخدام خدمتکار", SubCategoryId = 15, ImagePath = "\\Images\\Services\\29.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 30, BasePrice = 500, Name = "تعمیرات لباس", SubCategoryId = 16, ImagePath = "\\Images\\Services\\30.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 31, BasePrice = 500, Name = "دوخت لباس زنانه", SubCategoryId = 16, ImagePath = "\\Images\\Services\\31.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 32, BasePrice = 500, Name = "کیک و شیرینی", SubCategoryId = 17, ImagePath = "\\Images\\Services\\32.jpg", TimeCreated = new DateTime(2025, 10, 2) },
                new Service { Id = 33, BasePrice = 500, Name = "ارسال هدیه", SubCategoryId = 17, ImagePath = "\\Images\\Services\\33.jpg", TimeCreated = new DateTime(2025, 10, 2) }


                );
        }
    }
}
