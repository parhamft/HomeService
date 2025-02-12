using App.Infra.DB.SQLServer.EF.Configuration.AdminConfigs;
using App.Infra.DB.SQLServer.EF.Configuration.CategoryConfigs;
using App.Infra.DB.SQLServer.EF.Configuration.CItyConfigs;
using App.Infra.DB.SQLServer.EF.Configuration.CommentConfigs;
using App.Infra.DB.SQLServer.EF.Configuration.CustomerConfigs;
using App.Infra.DB.SQLServer.EF.Configuration.ExpertConfigs;
using App.Infra.DB.SQLServer.EF.Configuration.OfferConfigs;
using App.Infra.DB.SQLServer.EF.Configuration.OrderConfigs;
using App.Infra.DB.SQLServer.EF.Configuration.ServiceConfigs;
using App.Infra.DB.SQLServer.EF.Configuration.SubCategoryConfigs;
using App.Infra.DB.SQLServer.EF.Configuration.UserConfigs;
using HomeService.Domain.Core.HomeService.AdminEntity.Entities;
using HomeService.Domain.Core.HomeService.CategoryEntity.Entities;
using HomeService.Domain.Core.HomeService.CityEntity.Entities;
using HomeService.Domain.Core.HomeService.CommentEntity.Entities;
using HomeService.Domain.Core.HomeService.CustomerEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.HomeServiceEntity.Entities;
using HomeService.Domain.Core.HomeService.OfferEntity.Entities;
using HomeService.Domain.Core.HomeService.OrderEntity.Entities;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.Entities;
using HomeService.Domain.Core.HomeService.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DB.SQLServer.EF
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new AdminConfig());
            builder.ApplyConfiguration(new CategoryConfig());
            builder.ApplyConfiguration(new CityConfig());
            builder.ApplyConfiguration(new CommentConfig());
            builder.ApplyConfiguration(new CustomerConfig());
            builder.ApplyConfiguration(new ExpertConfig());
            builder.ApplyConfiguration(new OfferConfig());
            builder.ApplyConfiguration(new OrderConfig());
            builder.ApplyConfiguration(new ServiceConfig());
            builder.ApplyConfiguration(new SubCategoryConfig());

            UserConfig.SeedUsers(builder);

            //builder.Entity<IdentityUserLogin<int>>()
            //.HasKey(l => new { l.LoginProvider, l.ProviderKey });

            //builder.Entity<iden<int>>().HasNoKey();
            base.OnModelCreating(builder);




        }
        //public DbSet<User> users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Expert> Experts { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }

    }
}
