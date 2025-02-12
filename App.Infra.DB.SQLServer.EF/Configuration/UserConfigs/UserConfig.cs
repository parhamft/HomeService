using HomeService.Domain.Core.HomeService.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DB.SQLServer.EF.Configuration.UserConfigs
{
    public class UserConfig
    {

        public static void SeedUsers(ModelBuilder builder)
        {
            var hasher = new PasswordHasher<User>();

            var users = new List<User>
            {
            new User()
            {
                Id = 1,
                UserName = "Admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "Admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "09377507920",
                //SecurityStamp = Guid.NewGuid().ToString(),

            }
            };

            foreach (var user in users)
            {
                var passwordHasher = new PasswordHasher<User>();
                user.PasswordHash = passwordHasher.HashPassword(user, "123456");
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
