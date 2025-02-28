using App.Domain.AppService.HomeService.Account;
using HomeService.Domain.Core.HomeService.Account.AppService;
using HomeService.Domain.Core.HomeService.AdminEntity.AppServices;
using HomeService.Domain.Core.HomeService.Users.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Areas.Account.Controllers
{
    [Area(areaName: "Account")]
    public class LoginController : Controller
    {

        private readonly IAccountAppService _accountAppService;
        private readonly ILogger<LoginController> _logger;

        public LoginController(IAccountAppService accountAppService, ILogger<LoginController> logger)
        {

           _accountAppService = accountAppService;
            _logger = logger;
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
            var succeededLogin = await _accountAppService.Login(Email, Password,cancellationToken);
            if (succeededLogin.Succeeded)
            {
                _logger.LogInformation("شخصی در تاریخ {date}لاگ این کرد", DateTime.UtcNow.ToLongDateString());
                if (User.IsInRole("Admin"))
                {

                    return LocalRedirect("/Admin/Admin/Index");
                }

                if (User.IsInRole("Expert"))
                {
                    return LocalRedirect("/Home/Index");
                }

                if (User.IsInRole("Customer"))
                    return LocalRedirect("/Home/Index");
            }
            return RedirectToAction("Index");
        }
    }
}


