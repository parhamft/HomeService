using HomeService.Domain.Core.HomeService.OrderEntity.AppServices;
using HomeService.EndPoint.API.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderAppService _orderAppService;

        public OrdersController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }
        [HttpGet("GetOrders")]
        [ServiceFilter(typeof(ApiFilter))]
        public async Task<IActionResult> GetRequests(CancellationToken cancellationToken)
        {
            var requests = await _orderAppService.GetAll(cancellationToken);

            if (requests == null || requests.Count == 0)
                return NotFound(new { message = "هیچ درخواستی یافت نشد." });

            return Ok(requests);
        }
    }
}
