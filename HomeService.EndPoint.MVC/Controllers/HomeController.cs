using App.Domain.service.HomeService.CategoryEntity;
using HomeService.Domain.Core.HomeService.CategoryEntity.AppServices;
using HomeService.Domain.Core.HomeService.CategoryEntity.DTO;
using HomeService.Domain.Core.HomeService.ServiceEntity.AppServices;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.AppServices;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.DTO;
using HomeService.EndPoint.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _memoryCache;

        public HomeController(ILogger<HomeController> logger, ICategoryAppService categoryAppService,ISubCategoryAppService subCategoryAppService,IServiceAppService serviceAppService, IMemoryCache memoryCache)
        {
            _logger = logger;
            _categoryAppService = categoryAppService;
            _subCategoryAppService = subCategoryAppService;
            _serviceAppService = serviceAppService;
            _memoryCache = memoryCache;
        }

        public async Task<IActionResult> Index( CancellationToken cancellationToken)
        {
            _logger.LogInformation("شخصی در تاریخ {date}وارد هوم پیج شد",DateTime.UtcNow.ToLongDateString());
            List<GetCategoryDTO>? Categories;
            if (_memoryCache.Get("GetCategoryDTO") != null)
            {
                Categories = _memoryCache.Get<List<GetCategoryDTO>?>("GetCategoryDTO");
            }
            else
            {
                Categories = await _categoryAppService.GetAll(cancellationToken);
                _memoryCache.Set("GetCategoryDTO", Categories, TimeSpan.FromHours(2));
            }

            ViewBag.Categories = Categories;
            List<GetSubCategoryDTO>? result;
            if (_memoryCache.Get("GetSubCategoryDTO") != null)
            {
                result = _memoryCache.Get<List<GetSubCategoryDTO>?>("GetSubCategoryDTO");
            }
            else
            {
                result = await _subCategoryAppService.GetAll(cancellationToken); ;
                _memoryCache.Set("GetSubCategoryDTO", result, TimeSpan.FromHours(2));
            }


            ViewBag.SubCategories = result;
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
