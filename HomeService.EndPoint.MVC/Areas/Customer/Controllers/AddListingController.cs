using HomeService.Domain.Core.HomeService.CityEntity.AppServices;
using HomeService.Domain.Core.HomeService.CustomerEntity.AppServices;
using HomeService.Domain.Core.HomeService.OfferEntity.AppServices;
using HomeService.Domain.Core.HomeService.OrderEntity.AppServices;
using HomeService.Domain.Core.HomeService.OrderEntity.DTO;
using HomeService.Domain.Core.HomeService.ServiceEntity.AppServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace HomeService.EndPoint.MVC.Areas.Customer.Controllers
{
    [Authorize(Roles = "Customer")]
    [Area(areaName: "Customer")]
    public class AddListingController : Controller
    {
        private readonly IServiceAppService _serviceAppService;
        private readonly ICityAppService _cityAppService;
        private readonly IOfferAppService _offerAppService;
        private readonly ICustomerAppService _customerAppService;
        private readonly IOrderAppService _orderAppService;

        public AddListingController(IServiceAppService serviceAppService, ICityAppService cityAppService, IOfferAppService offerAppService, ICustomerAppService customerAppService,IOrderAppService orderAppService)
        {
            _serviceAppService = serviceAppService;
            _cityAppService = cityAppService;
            _offerAppService = offerAppService;
            _customerAppService = customerAppService;
            _orderAppService = orderAppService;
        }
        public async Task<IActionResult> Index(int id,int ServiceId, CancellationToken cancellationToken)
        {
            var Customer = await _customerAppService.GetById(id, cancellationToken);
            ViewBag.Customer = Customer;
                   var Services = await _serviceAppService.GetAll(cancellationToken);
            ViewBag.Services = Services;
            var Cities = await _cityAppService.GetAll(cancellationToken);
            ViewBag.Cities = Cities;
            ViewBag.ServiceId = ServiceId;


            return View();
        }
        public async Task<IActionResult> AddOrder(AddOrderDTO addOrderDTO, CancellationToken cancellationToken)
        {
            var result = await _orderAppService.Add(addOrderDTO, cancellationToken);
            return LocalRedirect($"/Customer/MyListing/Index/{addOrderDTO.CustomerId}");
        }

    }
}
