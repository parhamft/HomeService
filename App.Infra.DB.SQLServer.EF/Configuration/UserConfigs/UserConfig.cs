using HomeService.Domain.Core.HomeService.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DB.SQLServer.EF.Configuration.UserConfigs
{
    public static class UserConfig
    {

        public static void SeedUsers(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<User>();
            var x = Guid.Parse("e7cb88ca-5c61-4e15-aee1-b65f682eabc3");

            var users = new List<User>
            {
            new User()
            {
                Id = 1,
                UserName = "reza",
                NormalizedUserName = "REZA",
                Email = "Reza@gmail.com",
                NormalizedEmail = "REZA@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "09909169328",
                SecurityStamp = "025231bf-ced2-4d43-9b8b-54d97e9473ea",
                ConcurrencyStamp = "49533cdb-aeb8-452f-b2ac-64043551b8b3"

            },
            new User()
            {
                Id = 2,
                UserName = "Mohsen",
                NormalizedUserName = "MOHSEN",
                Email = "Mohsen@gmail.com",
                NormalizedEmail = "MOHSEN@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "09909169327",
                SecurityStamp = "025231bf-ced2-4d43-9b8b-54d97e9473ea",
                ConcurrencyStamp = "49533cdb-aeb8-452f-b2ac-64043551b8b3"

            }
            };

            foreach (var user in users)
            {
                var passwordHasher = new PasswordHasher<User>();
                user.PasswordHash = "AQAAAAIAAYagAAAAEPTvt7crCAFK/Q8+kIs/BDz8NS4sXLVTXvDH6qqrVr8YoTfdezBEWgyK9fVQMwNFvA==";
                builder.Entity<User>().HasData(user);
            }

            builder.Entity<IdentityRole<int>>().HasData(
            new IdentityRole<int>() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole<int>() { Id = 2, Name = "Customer", NormalizedName = "CUSTOMER" },
            new IdentityRole<int>() { Id = 3, Name = "Expert", NormalizedName = "EXPERT" });



            builder.Entity<IdentityUserRole<int>>().HasData(
            new IdentityUserRole<int>() { RoleId = 1, UserId = 1 });



        }
    }
}
