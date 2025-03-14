using HomeService.Domain.Core.HomeService.CommentEntity.AppServices;
using HomeService.Domain.Core.HomeService.ExpertEntity.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Controllers
{
    public class ExpertProfileController : Controller
    {
        private readonly IExpertAppService _expertAppService;
        private readonly IcommentAppService _icommentAppService;

        public ExpertProfileController(IExpertAppService expertAppService, IcommentAppService icommentAppService)
        {
            _expertAppService = expertAppService;
            _icommentAppService = icommentAppService;
        }
        public async Task<IActionResult> Index(int Id, CancellationToken cancellationToken)
        {
            var result = await _expertAppService.GetById(Id, cancellationToken);
            var Comments = await _icommentAppService.GetExpertsComments(Id, cancellationToken);
            ViewBag.Comments = Comments;
            return View(result);
        }
    }
}
