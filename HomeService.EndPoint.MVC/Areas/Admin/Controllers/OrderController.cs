using App.Domain.AppService.HomeService.OrderEntity;
using HomeService.Domain.Core.HomeService.OfferEntity.AppServices;
using HomeService.Domain.Core.HomeService.OfferEntity.DTO;
using HomeService.Domain.Core.HomeService.OrderEntity.AppServices;
using HomeService.Domain.Core.HomeService.OrderEntity.DTO;
using HomeService.Domain.Core.HomeService.OrderEntity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
            [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderAppService _orderAppService;
        private readonly IOfferAppService _offerAppService;


        public OrderController(IOrderAppService orderAppService, IOfferAppService offerAppService)
        {
            _orderAppService = orderAppService;
            _offerAppService = offerAppService;
        }
        public async  Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var result = await _orderAppService.GetAll(cancellationToken);
            return View(result);
        }
        public async Task<IActionResult> GetDetails(int Id,CancellationToken cancellationToken)
        {
            var Offers = await _offerAppService.GetAll(Id,cancellationToken);
            ViewBag.Offers = Offers;
            var result = await _orderAppService.GetById(Id,cancellationToken);
            return View(result);
        }
        public async Task<IActionResult> Update(int Status,int OrderId, CancellationToken cancellationToken)
        {
            try
            {

            await _orderAppService.ChangeStatus(OrderId, Status, cancellationToken);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                TempData["Message"] = ex.Message;
                TempData["AlertType"] = "danger";

                return RedirectToAction("Index");
            }
            
        }
        public async Task<IActionResult> Accept(int Id,int OrderId, CancellationToken cancellationToken)
        {
            var result = await _offerAppService.GetById(Id, cancellationToken);

            await _orderAppService.Update(result, cancellationToken);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteOffer(int Id, CancellationToken cancellationToken)
        {
            await _offerAppService.Delete(Id, cancellationToken);
            return RedirectToAction("index");
        }
    }
}
