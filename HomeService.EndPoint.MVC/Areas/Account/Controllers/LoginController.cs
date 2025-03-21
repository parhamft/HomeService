﻿using HomeService.Domain.Core.HomeService.Account.AppService;
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

            TempData["Message"] = "ایمیل یا رمز عبور اشتباه میباشد";
            TempData["AlertType"] = "danger";

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Logout(CancellationToken cancellationToken)
        {
            await _accountAppService.Logout(cancellationToken);
            return Redirect("/home");
        }
    }
}


