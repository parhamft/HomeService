using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Areas.Customer.Controllers
{
    public class Dashboard : Controller
    {
        [Area(areaName: "Customer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
