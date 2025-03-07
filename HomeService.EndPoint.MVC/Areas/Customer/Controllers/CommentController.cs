using HomeService.Domain.Core.HomeService.CommentEntity.AppServices;
using HomeService.Domain.Core.HomeService.CommentEntity.DTO;
using HomeService.Domain.Core.HomeService.CustomerEntity.AppServices;
using HomeService.Domain.Core.HomeService.CustomerEntity.DTO;
using HomeService.Domain.Core.HomeService.OfferEntity.AppServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Areas.Customer.Controllers
{
    [Authorize(Roles = "Customer")]
    [Area(areaName: "Customer")]
    public class CommentController : Controller
    {
        private readonly IcommentAppService _icommentAppService;
        private readonly ICustomerAppService _customerAppService;
        private readonly IOfferAppService _offerAppService;

        public CommentController(IcommentAppService icommentAppService, ICustomerAppService customerAppService, IOfferAppService offerAppService)
        {
            _icommentAppService = icommentAppService;
            _customerAppService = customerAppService;
            _offerAppService = offerAppService;
        }
        public async Task<IActionResult> Index(int id, CancellationToken cancellationToken)
        {
            var Customer = await _customerAppService.GetById(id, cancellationToken);
            ViewBag.Customer = Customer;
            var result = await _icommentAppService.GetUsersComments(id, cancellationToken);
            return View(result);
        }
        public async Task<IActionResult> AddComments(int id, int OfferId, CancellationToken cancellationToken)
        {
            var Customer = await _customerAppService.GetById(id, cancellationToken);
            ViewBag.Customer = Customer;
           var offer = await _offerAppService.GetById(OfferId, cancellationToken);
            ViewBag.offer = offer;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Addcomments(AddCommentDTO addCommentDTO, CancellationToken cancellationToken)
        {
            var result = await _icommentAppService.Create(addCommentDTO, cancellationToken);
            return LocalRedirect($"/Customer/Comment/Index/{addCommentDTO.CustomerId}");
        }
    }
}
