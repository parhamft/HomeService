using HomeService.Domain.Core.HomeService.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DB.SQLServer.EF.Configuration.UserConfigs
{
    public class UserConfig
    {

        public static void SeedUsers(ModelBuilder builder)
        {
            //var hasher = new PasswordHasher<User>();
            //var x = Guid.Parse("e7cb88ca-5c61-4e15-aee1-b65f682eabc3");

            //var users = new List<User>
            //{
            //new User()
            //{
            //    Id = 1,
            //    UserName = "reza",
            //    NormalizedUserName = "REZA@GMAIL.COM",
            //    Email = "Reza@gmail.com",
            //    NormalizedEmail = "REZA@GMAIL.COM",
            //    LockoutEnabled = false,
            //    PhoneNumber = "09909169328",
            //    SecurityStamp = "x.ToString(),"

            //}
            //};

            var user = new User()
            {
                Id = 1,
                UserName = "reza",
                NormalizedUserName = "REZA@GMAIL.COM",
                Email = "Reza@gmail.com",
                NormalizedEmail = "REZA@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "09909169328",
                SecurityStamp = "x.ToString(),",
                PasswordHash = "1234"

            };

            //foreach (var user in users)
            //{
            //    //var passwordHasher = new PasswordHasher<User>();
            //    user.PasswordHash ="123456";
            //    builder.Entity<User>().HasData(user);
            //}

            builder.Entity<User>().HasData(user);

            builder.Entity<IdentityRole<int>>().HasData(
            new IdentityRole<int>() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole<int>() { Id = 2, Name = "Customer", NormalizedName = "CUSTOMER" },
            new IdentityRole<int>() { Id = 3, Name = "Expert", NormalizedName = "EXPERT" });



            builder.Entity<IdentityUserRole<int>>().HasData(
            new IdentityUserRole<int>() { RoleId = 1, UserId = 1 });



        }
    }
}
