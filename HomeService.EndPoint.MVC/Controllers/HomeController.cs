using App.Domain.Service.HomeService.CategoryEntity;
using HomeService.Domain.Core.HomeService.CategoryEntity.AppServices;
using HomeService.Domain.Core.HomeService.ServiceEntity.AppServices;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.AppServices;
using HomeService.EndPoint.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading;

namespace HomeService.EndPoint.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryAppService _categoryAppService;
        private readonly ISubCategoryAppService _subCategoryAppService;
        private readonly IServiceAppService _serviceAppService;

        public HomeController(ILogger<HomeController> logger, ICategoryAppService categoryAppService,ISubCategoryAppService subCategoryAppService,IServiceAppService serviceAppService)
        {
            _logger = logger;
            _categoryAppService = categoryAppService;
            _subCategoryAppService = subCategoryAppService;
            _serviceAppService = serviceAppService;
        }

        public async Task<IActionResult> Index( CancellationToken cancellationToken)
        {
            _logger.LogInformation("شخصی در تاریخ {date}وارد هوم پیج شد",DateTime.UtcNow.ToLongDateString());
            var Categories = await _categoryAppService.GetAll( cancellationToken);
            ViewBag.Categories = Categories;
            var SubCategories = await _subCategoryAppService.GetAll(cancellationToken);
            ViewBag.SubCategories = SubCategories;
            var Services = await _serviceAppService.GetAll(cancellationToken);
            ViewBag.Services = Services;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
