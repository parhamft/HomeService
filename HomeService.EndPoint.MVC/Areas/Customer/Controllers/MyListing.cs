using HomeService.Domain.Core.HomeService.OfferEntity.AppServices;
using HomeService.Domain.Core.HomeService.OrderEntity.AppServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace HomeService.EndPoint.MVC.Areas.Customer.Controllers
{
    [Area(areaName: "Customer")]
    public class MyListing : Controller
    {
        private readonly IOrderAppService _orderAppService;
        private readonly IOfferAppService _offerAppService;

        public MyListing(IOrderAppService orderAppService, IOfferAppService offerAppService)
        {
            _orderAppService = orderAppService;
            _offerAppService = offerAppService;
        }
        public IActionResult Index()
        {

            return View();
        }
        public async Task<IActionResult> GetOffers(int Id, CancellationToken cancellationToken)
        {
            var Services = await _offerAppService.GetAll(Id, cancellationToken);
            ViewBag.Services = Services;
            return View();
        }
    }
}
