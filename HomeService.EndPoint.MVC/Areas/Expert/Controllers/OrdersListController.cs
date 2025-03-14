using HomeService.Domain.Core.HomeService.ExpertEntity.AppServices;
using HomeService.Domain.Core.HomeService.OfferEntity.AppServices;
using HomeService.Domain.Core.HomeService.OfferEntity.DTO;
using HomeService.Domain.Core.HomeService.OrderEntity.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Areas.Expert.Controllers
{
    [Area(areaName: "Expert")]
    public class OrdersListController : Controller
    {
        private readonly IOrderAppService _orderAppService;
        private readonly IExpertAppService _expertAppService;
        private readonly IOfferAppService _offerAppService;

        public OrdersListController(IOrderAppService orderAppService, IExpertAppService expertAppService, IOfferAppService offerAppService)
        {
            _orderAppService = orderAppService;
            _expertAppService = expertAppService;
            _offerAppService = offerAppService;
        }
        public async Task<IActionResult> Index(int Id, CancellationToken cancellationToken)
        {
            var expert = await _expertAppService.GetById(Id, cancellationToken);
            ViewBag.Expert = expert;
            var result = await _expertAppService.GetOrdersForExpert(expert, cancellationToken);
            return View(result);
        }
        public async Task<IActionResult> Details(int Id, int OrderId, CancellationToken cancellationToken)
        {
            var expert = await _expertAppService.GetById(Id, cancellationToken);
            ViewBag.Expert = expert;
            var result = await _orderAppService.GetById(OrderId, cancellationToken);
            return View(result);
        }
        public async Task<IActionResult> AddOffer(int Id, int OrderId, CancellationToken cancellationToken)
        {

            var expert = await _expertAppService.GetById(Id, cancellationToken);
            ViewBag.Expert = expert;
            ViewBag.OrderId = OrderId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Addoffer(AddOfferDTO addOfferDTO, CancellationToken cancellationToken)
        {
            try

            {
                var order = await _orderAppService.GetById(addOfferDTO.OrderId, cancellationToken);

                addOfferDTO.RequestTime = order.DateFor;
                if (order.Service.BasePrice > addOfferDTO.Price)
                {
                    TempData["Message"] = "قیمت باید بیشتر از حداقل قیمت باشد";
                    TempData["AlertType"] = "danger";
                    return LocalRedirect($"/Expert/OrdersList/AddOffer/{addOfferDTO.ExpertId}?OrderId={addOfferDTO.OrderId}");
                }

                await _offerAppService.Add(addOfferDTO, cancellationToken);
            }
            catch (Exception ex)
            {
                TempData["Message"] = ex.Message;
                TempData["AlertType"] = "danger";
                return LocalRedirect($"/Expert/OrdersList/AddOffer/{addOfferDTO.ExpertId}?OrderId={addOfferDTO.OrderId}");
            }
            return LocalRedirect($"/Expert/OrdersList/Index/{addOfferDTO.ExpertId}?OrderId={addOfferDTO.OrderId}");
        }
    }
}
