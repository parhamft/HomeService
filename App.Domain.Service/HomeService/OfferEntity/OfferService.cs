using HomeService.Domain.Core.HomeService.OfferEntity.Data;
using HomeService.Domain.Core.HomeService.OfferEntity.DTO;
using HomeService.Domain.Core.HomeService.OfferEntity.Entities;
using HomeService.Domain.Core.HomeService.OfferEntity.Services;
using HomeService.Domain.Core.HomeService.OrderEntity.Data;
using HomeService.Domain.Core.HomeService.OrderEntity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.service.HomeService.OfferEntity
{
    public class OfferService : IOfferService
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IOrderRepository _orderRepository;

        public OfferService(IOfferRepository offerRepository,IOrderRepository orderRepository)
        {
            _offerRepository = offerRepository;
            _orderRepository = orderRepository;
        }
        public async Task<bool> Add(AddOfferDTO addOrderDTO, CancellationToken cancellationToken)
        {
            var result = await _offerRepository.Create(addOrderDTO, cancellationToken);
            return result;
        }
        public async Task<List<GetOfferDTO>> GetAll(int id,CancellationToken cancellationToken)
        {
            var result = await _offerRepository.GetAll(id,cancellationToken);
            return result;
        }
        public async Task<GetOfferDTO> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _offerRepository.GetById(id, cancellationToken);
            return result;
        }

        public async Task<bool> Update(Offer orderStatusUpdateDTO, CancellationToken cancellationToken)
        {
            var result = await _offerRepository.Update(orderStatusUpdateDTO, cancellationToken);
            return result;

        }
        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var result = await _offerRepository.Delete(id, cancellationToken);
            return result;
        }
        //public async Task<bool> CheckCity(AddOfferDTO addOfferDTO, CancellationToken cancellationToken)
        //{
        //   var result = await _orderRepository.GetById(addOfferDTO.OrderId, cancellationToken);
            
        //}
    }
}
