using HomeService.Domain.Core.HomeService.OrderEntity.Data;
using HomeService.Domain.Core.HomeService.OrderEntity.DTO;
using HomeService.Domain.Core.HomeService.OrderEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.HomeService.OrderEntity
{
    public class OrderAppService
    {
        private readonly IOrderService _orderService;

        public OrderAppService(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<bool> Add(AddOrderDTO addOrderDTO, CancellationToken cancellationToken)
        {
            var result = await _orderService.Add(addOrderDTO, cancellationToken);
            return result;
        }
        public async Task<List<GetOrderDTO>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _orderService.GetAll(cancellationToken);
            return result;
        }
        public async Task<GetOrderDTO> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _orderService.GetById(id, cancellationToken);
            return result;
        }
        public async Task<bool> Update(OrderStatusUpdateDTO orderStatusUpdateDTO, CancellationToken cancellationToken)
        {
            var result = await _orderService.Update(orderStatusUpdateDTO, cancellationToken);
            return result;

        }
        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _orderService.Delete(id, cancellationToken);
            return result;
        }
    }
}
