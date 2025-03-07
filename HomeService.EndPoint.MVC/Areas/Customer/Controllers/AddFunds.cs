using HomeService.Domain.Core.HomeService.CustomerEntity.AppServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace HomeService.EndPoint.MVC.Areas.Customer.Controllers
{

    [Area(areaName: "Customer")]
    [Authorize(Roles = "Customer")]
    public class AddFunds : Controller
    {
        private readonly ICustomerAppService _customerAppService;

        public AddFunds(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }
        public async Task<IActionResult> Index(int id, CancellationToken cancellationToken)
        {
            var Customer = await _customerAppService.GetById(id, cancellationToken);
            ViewBag.Customer = Customer;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Transaction(int id, decimal amount, CancellationToken cancellationToken)
        {
            var Customer = await _customerAppService.GetById(id, cancellationToken);
            ViewBag.Customer = Customer;
            var UpCus = await _customerAppService.GetUpdateDTO(id, cancellationToken);
            UpCus.Balance += amount;
            await _customerAppService.Update(UpCus, cancellationToken);
            return LocalRedirect($"/Customer/Dashboard/Index/{id}");
        }
    }
}
