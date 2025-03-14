using HomeService.Domain.Core.HomeService.CommentEntity.AppServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CommentController : Controller
    {
        private readonly IcommentAppService _icommentAppService;

        public CommentController(IcommentAppService icommentAppService)
        {
            _icommentAppService = icommentAppService;
        }
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var result = await _icommentAppService.GetPendings(cancellationToken);
            return View(result);
        }
        public async Task<IActionResult> GetApproved(CancellationToken cancellationToken)
        {
            var result = await _icommentAppService.GetApproved(cancellationToken);
            return View(result);
        }
        public async Task<IActionResult> GetDisApproved(CancellationToken cancellationToken)
        {
            var result = await _icommentAppService.GetDissaproved(cancellationToken);
            return View(result);
        }
        public async Task <IActionResult> Approve(int id,int ExpertId, CancellationToken cancellationToken)
        {
            await _icommentAppService.ChangeStatus(id, 1, ExpertId, cancellationToken);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DisApprove(int id,int ExpertId ,CancellationToken cancellationToken)
        {
            await _icommentAppService.ChangeStatus(id, 2, ExpertId, cancellationToken);
            return RedirectToAction("Index");
        }

    }
}
