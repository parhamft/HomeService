using App.Domain.AppService.HomeService.Account;
using HomeService.Domain.Core.HomeService.AdminEntity.AppServices;
using HomeService.Domain.Core.HomeService.Users.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Areas.Account.Controllers
{
    [Area(areaName: "Account")]
    public class Login : Controller
    {
        private readonly IAdminAppService _adminAppService;

        public Login(IAdminAppService adminAppService)
        {
            _adminAppService = adminAppService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> login(string Email,string Password,CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");
            var succeededLogin = await _adminAppService.Login(Email, Password,cancellationToken);
            if (succeededLogin.Succeeded)
            {

                if (User.IsInRole("Admin"))
                {

                    return LocalRedirect("/Admin/Admin/Index");
                }

                if (User.IsInRole("Expert"))
                {
                    return LocalRedirect("/Expert/Index");
                }

                if (User.IsInRole("Customer"))
                    return LocalRedirect("/Customer/Index");
            }
            return RedirectToAction("Index");
        }
    }
}


