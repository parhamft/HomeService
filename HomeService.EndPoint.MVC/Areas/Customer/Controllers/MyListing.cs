using HomeService.Domain.Core.HomeService.CustomerEntity.AppServices;
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
        private readonly ICustomerAppService _customerAppService;

        public MyListing(IOrderAppService orderAppService, IOfferAppService offerAppService, ICustomerAppService customerAppService)
        {
            _orderAppService = orderAppService;
            _offerAppService = offerAppService;
            _customerAppService = customerAppService;
        }
        public async Task<IActionResult> Index(int Id, CancellationToken cancellationToken)
        {
            var result = await _customerAppService.GetById(Id, cancellationToken);
            return View(result);
        }
        public async Task<IActionResult> GetOffers(int Id, CancellationToken cancellationToken)
        {
            var Offers = await _offerAppService.GetAll(Id, cancellationToken);
            ViewBag.Offers = Offers;
            return View();
        }
    }
}
