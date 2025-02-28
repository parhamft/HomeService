using HomeService.Domain.Core.HomeService.Account.AppService;
using HomeService.Domain.Core.HomeService.CityEntity.AppServices;
using HomeService.Domain.Core.HomeService.CustomerEntity.DTO;
using HomeService.Domain.Core.HomeService.UserEntity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Areas.Account.Controllers
{
    [Area(areaName: "Account")]
    public class Register : Controller
    {
        private readonly ICityAppService _cityAppService;
        private readonly IAccountAppService _accountAppService;

        public Register(ICityAppService cityAppService, IAccountAppService accountAppService)
        {
            _cityAppService = cityAppService;
            _accountAppService = accountAppService;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var Cities = await _cityAppService.GetAll(cancellationToken) ;
            ViewBag.Cities = Cities;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> register(CreateUserDTO createUserDTO, CancellationToken cancellationToken)
        {
            var result = await _accountAppService.Register(createUserDTO, cancellationToken);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    TempData["Message"] = error.Description;
                    TempData["AlertType"] = "danger";
                }
                return RedirectToAction("Index");
            }

        }
    }
}
