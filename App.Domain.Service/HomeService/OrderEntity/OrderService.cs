using HomeService.Domain.Core.HomeService.CityEntity.Entities;
using HomeService.Domain.Core.HomeService.OrderEntity.Data;
using HomeService.Domain.Core.HomeService.OrderEntity.DTO;
using HomeService.Domain.Core.HomeService.OrderEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.service.HomeService.OrderEntity
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
        public async Task<List<GetOrderDTO>> GetAllAccepted(int ExpertId, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetAllAccepted(ExpertId, cancellationToken);
        }
        public async Task<List<GetOrderDTO>> GetOrdersForExpert(List<int> Services, int? CityId, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrdersForExpert(Services, CityId, cancellationToken);
        }
        public async Task<List<GetOrderDTO>> GetAllOfUsers(int id, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.GetAllOfUsers(id,cancellationToken);
            return result;
        }
        public async Task<GetOrderDTO> GetById(int id, CancellationToken cancellationToken)
        {
            var result =  await _orderRepository.GetById(id, cancellationToken);
            return result;
        }
        public async Task<bool> CheckForDuplicateOffersOfExpert(int id,int ExpertId, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.GetById(id, cancellationToken);
            if (result.Offers==null)
            {
                return false;
            }
            foreach (var i in result.Offers)
            {
                if (i.ExpertId==ExpertId)
                {
                    return true;
                }
            }
            return false;
        }
        public async Task<bool> Update(GetOrderDTO getOrderDTO, CancellationToken cancellationToken)
        {
            var order = new OrderStatusUpdateDTO
            {
                Expert = getOrderDTO.Expert,
                Status = getOrderDTO.Status,
                Id = getOrderDTO.Id
            };
            var result = await _orderRepository.Update(order, cancellationToken);
            return result;

        }
        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.Delete(id, cancellationToken);
            return result;
        }
        public async Task<bool> CheckIfOffersExist(int id, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.GetById(id,cancellationToken);
            if (result.Offers == null)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> CheckExpert(int id, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.GetById(id, cancellationToken);
            if (result.Expert == null)
            {
                return false;
            }
            return true;
        }
    }
}
