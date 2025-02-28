using HomeService.Domain.Core.HomeService.CityEntity.AppServices;
using HomeService.Domain.Core.HomeService.OfferEntity.AppServices;
using HomeService.Domain.Core.HomeService.ServiceEntity.AppServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace HomeService.EndPoint.MVC.Areas.Customer.Controllers
{

    [Area(areaName: "Customer")]
    public class AddListing : Controller
    {
        private readonly IServiceAppService _serviceAppService;
        private readonly ICityAppService _cityAppService;
        private readonly IOfferAppService _offerAppService;

        public AddListing(IServiceAppService serviceAppService, ICityAppService cityAppService, IOfferAppService offerAppService)
        {
            _serviceAppService = serviceAppService;
            _cityAppService = cityAppService;
            _offerAppService = offerAppService;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var Services = await _serviceAppService.GetAll(cancellationToken);
            ViewBag.Services = Services;
            var Cities = await _cityAppService.GetAll(cancellationToken);
            ViewBag.Cities = Cities;
            return View();
        }

    }
}
