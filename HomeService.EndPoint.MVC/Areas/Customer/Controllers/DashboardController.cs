using HomeService.Domain.Core.HomeService.CustomerEntity.AppServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Areas.Customer.Controllers
{
    [Authorize(Roles = "Customer")]
    public class DashboardController : Controller
    {
        private readonly ICustomerAppService _customerAppService;

        public DashboardController(ICustomerAppService customerAppService)
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
