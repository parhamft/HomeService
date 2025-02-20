using HomeService.Domain.Core.HomeService.OrderEntity.Data;
using HomeService.Domain.Core.HomeService.OrderEntity.DTO;
using HomeService.Domain.Core.HomeService.OrderEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service.HomeService.OrderEntity
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<bool> Add(AddOrderDTO addOrderDTO,CancellationToken cancellationToken)
        {
             var result = await _orderRepository.Create(addOrderDTO, cancellationToken);
            return result;
        }
        public async Task<List<GetOrderDTO>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _orderRepository.GetAll(cancellationToken);
            return result;
        }
        public async Task<GetOrderDTO> GetById(int id, CancellationToken cancellationToken)
        {
            var result =  await _orderRepository.GetById(id, cancellationToken);
            return result;
        }
        public async Task<bool> Update(OrderStatusUpdateDTO orderStatusUpdateDTO, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.Update(orderStatusUpdateDTO, cancellationToken);
            return result;

        }
        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.Delete(id, cancellationToken);
            return result;
        } 
    }
}
