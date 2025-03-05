using HomeService.Domain.Core.HomeService.CategoryEntity.AppServices;
using HomeService.Domain.Core.HomeService.ServiceEntity.AppServices;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.AppServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace HomeService.EndPoint.MVC.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryAppService _categoryAppService;
        private readonly ISubCategoryAppService _subCategoryAppService;
        private readonly IServiceAppService _serviceAppService;

        public ServiceController(ILogger<HomeController> logger, ICategoryAppService categoryAppService, ISubCategoryAppService subCategoryAppService, IServiceAppService serviceAppService)
        {
            _logger = logger;
            _categoryAppService = categoryAppService;
            _subCategoryAppService = subCategoryAppService;
            _serviceAppService = serviceAppService;
        }

        public async Task<IActionResult> Index(int Id,CancellationToken cancellationToken)
        {
            _logger.LogInformation("شخصی در تاریخ {date} وارد سرویس پیج شد", DateTime.UtcNow.ToLongDateString);
            var Services = await _serviceAppService.GetAllSubCategoryOf( Id,cancellationToken);
            ViewBag.Services = Services;
            return View();
        }

    }
}
