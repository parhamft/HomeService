using HomeService.Domain.Core.HomeService.CityEntity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DB.SQLServer.EF.Configuration.CItyConfigs
{
    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titel)
                   .IsRequired();

            builder.HasData(
    new City { Id = 1, Titel = "آذربایجان شرقی" },
    new City { Id = 2, Titel = "آذربایجان غربی" },
    new City { Id = 3, Titel = "اردبیل" },
    new City { Id = 4, Titel = "اصفهان" },
    new City { Id = 5, Titel = "البرز" },
    new City { Id = 6, Titel = "ایلام" },
    new City { Id = 7, Titel = "بوشهر" },
    new City { Id = 8, Titel = "تهران" },
    new City { Id = 9, Titel = "چهارمحال و بختیاری" },
    new City { Id = 10, Titel = "خراسان جنوبی" },
    new City { Id = 11, Titel = "خراسان رضوی" },
    new City { Id = 12, Titel = "خراسان شمالی" },
    new City { Id = 13, Titel = "خوزستان" },
    new City { Id = 14, Titel = "زنجان" },
    new City { Id = 15, Titel = "سمنان" },
    new City { Id = 16, Titel = "سیستان و بلوچستان" },
    new City { Id = 17, Titel = "فارس" },
    new City { Id = 18, Titel = "قزوین" },
    new City { Id = 19, Titel = "قم" },
    new City { Id = 20, Titel = "کردستان" },
    new City { Id = 21, Titel = "کرمان" },
    new City { Id = 22, Titel = "کرمانشاه" },
    new City { Id = 23, Titel = "کهگیلویه و بویراحمد" },
    new City { Id = 24, Titel = "گلستان" },
    new City { Id = 25, Titel = "گیلان" },
    new City { Id = 26, Titel = "لرستان" },
    new City { Id = 27, Titel = "مازندران" },
    new City { Id = 28, Titel = "مرکزی" },
    new City { Id = 29, Titel = "هرمزگان" },
    new City { Id = 30, Titel = "همدان" },
    new City { Id = 31, Titel = "یزد" }
    );
        }
    }
}
