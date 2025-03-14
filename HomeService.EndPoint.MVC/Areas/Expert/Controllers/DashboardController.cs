using HomeService.Domain.Core.HomeService.ExpertEntity.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Areas.Expert.Controllers
{
    [Area("Expert")]
    public class DashboardController : Controller
    {
        private readonly IExpertAppService _expertAppService;

        public DashboardController(IExpertAppService expertAppService)
        {
            _expertAppService = expertAppService;
        }
        public async Task<IActionResult> Index(int Id, CancellationToken cancellationToken)
        {

            var Expert = await _expertAppService.GetById(Id, cancellationToken);
            ViewBag.Expert = Expert;
            return View();
        }
    }
}
