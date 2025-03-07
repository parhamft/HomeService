using HomeService.Domain.Core.HomeService.CustomerEntity.AppServices;
using HomeService.Domain.Core.HomeService.CustomerEntity.DTO;
using HomeService.Domain.Core.HomeService.OfferEntity.AppServices;
using HomeService.Domain.Core.HomeService.OrderEntity.AppServices;
using HomeService.Domain.Core.HomeService.OrderEntity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace HomeService.EndPoint.MVC.Areas.Customer.Controllers
{
    [Authorize(Roles = "Customer")]
    [Area(areaName: "Customer")]
    public class MyListingController : Controller
    {
        private readonly IOrderAppService _orderAppService;
        private readonly IOfferAppService _offerAppService;
        private readonly ICustomerAppService _customerAppService;

        public MyListingController(IOrderAppService orderAppService, IOfferAppService offerAppService, ICustomerAppService customerAppService)
        {
            _orderAppService = orderAppService;
            _offerAppService = offerAppService;
            _customerAppService = customerAppService;
        }
        public async Task<IActionResult> Index(int Id, CancellationToken cancellationToken)
        {
            var Customer = await _customerAppService.GetById(Id, cancellationToken);
            ViewBag.Customer = Customer;
            var Orders = await _orderAppService.GetAllOfUsers(Id, cancellationToken);

            return View(Orders);
        }
        public async Task<IActionResult> GetOffers(int OrderId,int Id, CancellationToken cancellationToken)
        {
            var Customer = await _customerAppService.GetById(Id, cancellationToken);
            ViewBag.Customer = Customer;
            var Order = await _orderAppService.GetById(OrderId, cancellationToken);
            ViewBag.Order = Order;
            var Offers = await _offerAppService.GetAll(OrderId, cancellationToken);
            ViewBag.Offers = Offers;

            return View();
        }
        public async Task<IActionResult> Accept(int Id, int OrderId, CancellationToken cancellationToken)
        {
            var result = await _offerAppService.GetById(Id, cancellationToken);

            await _orderAppService.Update(result, cancellationToken);
            return LocalRedirect($"/Customer/MyListing/Index/{result.Order.CustomerId}");
        }
        public async Task<IActionResult> DeleteOffer(int Id,int CustomerId, CancellationToken cancellationToken)
        {

            await _offerAppService.Delete(Id, cancellationToken);
            return LocalRedirect($"/Customer/MyListing/Index/{CustomerId}");
        }
        [HttpPost]
        public async Task<IActionResult> Pay(int Orderid,int id, decimal amount,CancellationToken cancellationToken)
        {
            var result = await _customerAppService.Transaction(Orderid, amount, cancellationToken);
            if (result == false)
            {

                TempData["Message"] = "موجودی نا کافی";
                TempData["AlertType"] = "danger";

                return LocalRedirect($"/Customer/MyListing/Index/{id}");
            }
            await _orderAppService.ChangeStatus(Orderid, 5,cancellationToken);
            return LocalRedirect($"/Customer/MyListing/Index/{id}");
        }
    }
}
