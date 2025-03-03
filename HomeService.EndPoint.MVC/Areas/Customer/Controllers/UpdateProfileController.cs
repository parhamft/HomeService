using HomeService.Domain.Core.HomeService.CustomerEntity.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Areas.Customer.Controllers
{
    public class UpdateProfileController : Controller
    {
        private readonly ICustomerAppService _customerAppService;

        public UpdateProfileController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }
        [Area(areaName: "Customer")]
        public async Task<IActionResult> Index(int Id,CancellationToken cancellationToken)
        {
            var result = await _customerAppService.GetUpdateDTO(Id, cancellationToken);
            return View(result);
        }
    }
}
