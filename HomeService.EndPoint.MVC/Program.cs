using App.Domain.AppService.HomeService.Account;
using App.Domain.AppService.HomeService.AdminEntity;
using App.Domain.AppService.HomeService.CategoryEntity;
using App.Domain.AppService.HomeService.CityEntity;
using App.Domain.AppService.HomeService.CommentEntity;
using App.Domain.AppService.HomeService.CustomerEntity;
using App.Domain.AppService.HomeService.ExpertEntity;
using App.Domain.AppService.HomeService.OfferEntity;
using App.Domain.AppService.HomeService.OrderEntity;
using App.Domain.AppService.HomeService.ServiceEntity;
using App.Domain.AppService.HomeService.SubCategoryEntity;
using App.Domain.Service.HomeService.AdminEntity;
using App.Domain.Service.HomeService.BaseDataService;
using App.Domain.Service.HomeService.CategoryEntity;
using App.Domain.Service.HomeService.CityEntity;
using App.Domain.Service.HomeService.CommentEntity;
using App.Domain.Service.HomeService.CustomerEntity;
using App.Domain.Service.HomeService.ExpertEntity;
using App.Domain.Service.HomeService.OfferEntity;
using App.Domain.Service.HomeService.OrderEntity;
using App.Domain.Service.HomeService.ServiceEntity;
using App.Domain.Service.HomeService.SubCategoryEntity;
using App.Infra.DataAccess.Repo.EF.HomeService.AdminEntity;
using App.Infra.DataAccess.Repo.EF.HomeService.CategoryEntity;
using App.Infra.DataAccess.Repo.EF.HomeService.CityEntity;
using App.Infra.DataAccess.Repo.EF.HomeService.CommentEntity;
using App.Infra.DataAccess.Repo.EF.HomeService.CustomerEntity;
using App.Infra.DataAccess.Repo.EF.HomeService.ExpertEntity;
using App.Infra.DataAccess.Repo.EF.HomeService.OfferEntity;
using App.Infra.DataAccess.Repo.EF.HomeService.OrderEntity;
using App.Infra.DataAccess.Repo.EF.HomeService.ServiceEntity;
using App.Infra.DataAccess.Repo.EF.HomeService.SubCategoryEntity;
using App.Infra.DataAccess.Repo.EF.HomeService.UserEntity;
using App.Infra.DB.SQLServer.EF;
using Divarcheh.Endpoints.RazorPages.Middleware;
using HomeService.Domain.Core.HomeService.Account.AppService;
using HomeService.Domain.Core.HomeService.AdminEntity.AppServices;
using HomeService.Domain.Core.HomeService.AdminEntity.Data;
using HomeService.Domain.Core.HomeService.AdminEntity.Services;
using HomeService.Domain.Core.HomeService.BaseData.Service;
using HomeService.Domain.Core.HomeService.CategoryEntity.AppServices;
using HomeService.Domain.Core.HomeService.CategoryEntity.Data;
using HomeService.Domain.Core.HomeService.CategoryEntity.Services;
using HomeService.Domain.Core.HomeService.CityEntity.AppServices;
using HomeService.Domain.Core.HomeService.CityEntity.Data;
using HomeService.Domain.Core.HomeService.CityEntity.Services;
using HomeService.Domain.Core.HomeService.CommentEntity.AppServices;
using HomeService.Domain.Core.HomeService.CommentEntity.Data;
using HomeService.Domain.Core.HomeService.CommentEntity.Services;
using HomeService.Domain.Core.HomeService.Configs.Entities;
using HomeService.Domain.Core.HomeService.CustomerEntity.AppServices;
using HomeService.Domain.Core.HomeService.CustomerEntity.Data;
using HomeService.Domain.Core.HomeService.CustomerEntity.Services;
using HomeService.Domain.Core.HomeService.ExpertEntity.AppServices;
using HomeService.Domain.Core.HomeService.ExpertEntity.Data;
using HomeService.Domain.Core.HomeService.ExpertEntity.Services;
using HomeService.Domain.Core.HomeService.OfferEntity.AppServices;
using HomeService.Domain.Core.HomeService.OfferEntity.Data;
using HomeService.Domain.Core.HomeService.OfferEntity.Services;
using HomeService.Domain.Core.HomeService.OrderEntity.AppServices;
using HomeService.Domain.Core.HomeService.OrderEntity.Data;
using HomeService.Domain.Core.HomeService.OrderEntity.Services;
using HomeService.Domain.Core.HomeService.ServiceEntity.AppServices;
using HomeService.Domain.Core.HomeService.ServiceEntity.Data;
using HomeService.Domain.Core.HomeService.ServiceEntity.Services;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.AppServices;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.Data;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.Entities;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.Services;
using HomeService.Domain.Core.HomeService.UserEntity.Data;
using HomeService.Domain.Core.HomeService.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;

Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Host.ConfigureLogging(o =>
{
    o.ClearProviders();
    o.AddSerilog();
}).UseSerilog((context, config) =>
{
    config.WriteTo.Console();
    config.WriteTo.Seq("http://localhost:5341", apiKey: "QyS1UFEr4WvSYTlj1E20");
});
try
{

    var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
    var siteSettings = configuration.GetSection("SiteSettings").Get<SiteSettings>();
    builder.Services.AddSingleton(siteSettings);

    builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(siteSettings.ConnectionStrings.SqlConnection));

    builder.Services.AddIdentity<User, IdentityRole<int>>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;

    })
        .AddRoles<IdentityRole<int>>()
        .AddEntityFrameworkStores<AppDbContext>()
        .AddDefaultTokenProviders();

    builder.Services.ConfigureApplicationCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.Cookie.MaxAge = null;

    });

    builder.Services.AddMemoryCache();


    builder.Services.AddScoped<IAdminRepository, AdminRepository>();
    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
    builder.Services.AddScoped<ICityRepository, CityRepository>();
    builder.Services.AddScoped<ICommentRepository, CommentRepository>();
    builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
    builder.Services.AddScoped<IExpertRepository, ExpertRepository>();
    builder.Services.AddScoped<IOfferRepository, OfferRepository>();
    builder.Services.AddScoped<IOrderRepository, OrderRepository>();
    builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
    builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();

    builder.Services.AddScoped<IAdminService, AdminService>();
    builder.Services.AddScoped<ICategoryService, CategoryService>();
    builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
    builder.Services.AddScoped<IServiceService, ServiceService>();
    builder.Services.AddScoped<IBaseDataService, BaseDataService>();
    builder.Services.AddScoped<IOrderService, OrderService>();
    builder.Services.AddScoped<IOfferService, OfferService>();
    builder.Services.AddScoped<ICommentService, CommentService>();
    builder.Services.AddScoped<ICityService, CityService>();
    builder.Services.AddScoped<ICustomerService, CustomerService>();
    builder.Services.AddScoped<IExpertService, ExpertService>();


    builder.Services.AddScoped<IAdminAppService, AdminAppServie>();
    builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();
    builder.Services.AddScoped<IServiceAppService, ServiceAppService>();
    builder.Services.AddScoped<ISubCategoryAppService, SubCategoryAppService>();
    builder.Services.AddScoped<IOrderAppService, OrderAppService>();
    builder.Services.AddScoped<IOfferAppService, OfferAppService>();
    builder.Services.AddScoped<IcommentAppService, CommentAppService>();
    builder.Services.AddScoped<ICityAppService, CityAppService>();
    builder.Services.AddScoped<IAccountAppService, AccountAppService>();
    builder.Services.AddScoped<ICustomerAppService, CustomerAppService>();
    builder.Services.AddScoped<IExpertAppService, ExpertAppService>();


    //builder.Logging.AddSeq("http://localhost:5341/", "4745f464-06b8-44ff-8207-198783c1928e");

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    //app.UseErrorLogging();
    app.UseHttpsRedirection();
    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapStaticAssets();

    app.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();


    app.Run();

}
catch(Exception ex) 
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}