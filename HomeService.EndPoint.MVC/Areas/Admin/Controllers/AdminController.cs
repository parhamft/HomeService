using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Areas.Admin.Controllers
{
    [Area(areaName:"Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
