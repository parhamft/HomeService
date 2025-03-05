using HomeService.Domain.Core.HomeService.CustomerEntity.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Areas.Customer.Controllers
{
    public class Dashboard : Controller
    {
        private readonly ICustomerAppService _customerAppService;

        public Dashboard(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }
        [Area(areaName: "Customer")]
        public async Task<IActionResult> Index(int id,CancellationToken cancellationToken)
        {
            var Customer = await _customerAppService.GetById(id, cancellationToken);
            ViewBag.Customer = Customer;
            return View();
        }
    }
}
