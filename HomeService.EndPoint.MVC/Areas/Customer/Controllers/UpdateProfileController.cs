using HomeService.Domain.Core.HomeService.CustomerEntity.AppServices;
using HomeService.Domain.Core.HomeService.CustomerEntity.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Areas.Customer.Controllers
{
    [Authorize(Roles = "Customer")]
    [Area(areaName: "Customer")]
    public class UpdateProfileController : Controller
    {
        private readonly ICustomerAppService _customerAppService;

        public UpdateProfileController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        public async Task<IActionResult> Index(int Id,CancellationToken cancellationToken)
        {
            var Customer = await _customerAppService.GetById(Id, cancellationToken);
            ViewBag.Customer = Customer;
            var result = await _customerAppService.GetUpdateDTO(Id, cancellationToken);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCustomerDTO updateCustomerDTO, CancellationToken cancellationToken)
        {
            await _customerAppService.Update(updateCustomerDTO, cancellationToken);
            return LocalRedirect($"/Customer/Dashboard/Index/{updateCustomerDTO.Id}");
        }
    }
}
