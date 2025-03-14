using HomeService.Domain.Core.HomeService.ExpertEntity.AppServices;
using HomeService.Domain.Core.HomeService.OrderEntity.AppServices;
using HomeService.Domain.Core.HomeService.OrderEntity.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Areas.Expert.Controllers
{
    [Area(areaName: "Expert")]
    [Authorize(Roles = "Expert")]
    public class MyJobs : Controller
    {
        private readonly IOrderAppService _orderAppService;
        private readonly IExpertAppService _expertAppService;

        public MyJobs(IOrderAppService orderAppService, IExpertAppService expertAppService)
        {
            _orderAppService = orderAppService;
            _expertAppService = expertAppService;
        }
        public async Task<IActionResult> Index(int Id,CancellationToken cancellationToken)
        {
            var expert = await _expertAppService.GetById(Id,cancellationToken);
            ViewBag.Expert = expert;
            var result = await _orderAppService.GetAllAccepted(Id, cancellationToken);
            return View(result);
        }
        public async Task<IActionResult> FinishJob(int Id, int OrderId, CancellationToken cancellationToken)
        {
            await _expertAppService.FinishJob(OrderId,cancellationToken);
            return LocalRedirect($"/Expert/MyJobs/Index/{Id}");
        }

    }
}
