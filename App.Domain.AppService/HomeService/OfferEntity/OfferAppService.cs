using HomeService.Domain.Core.HomeService.OfferEntity.AppServices;
using HomeService.Domain.Core.HomeService.OfferEntity.DTO;
using HomeService.Domain.Core.HomeService.OfferEntity.Entities;
using HomeService.Domain.Core.HomeService.OfferEntity.Services;
using HomeService.Domain.Core.HomeService.OrderEntity.DTO;
using HomeService.Domain.Core.HomeService.OrderEntity.Entities;
using HomeService.Domain.Core.HomeService.OrderEntity.Enums;
using HomeService.Domain.Core.HomeService.OrderEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.HomeService.OfferEntity
{
    public class OfferAppService : IOfferAppService
    {
        private readonly IOfferService _offerService;
        private readonly IOrderService _orderService;

        public OfferAppService(IOfferService offerService, IOrderService orderService)
        {
            _offerService = offerService;
            _orderService = orderService;
        }
        public async Task<bool> Add(AddOfferDTO AddOfferDTO, CancellationToken cancellationToken)
        {

            var order=new GetOrderDTO
            {
                Id = AddOfferDTO.OrderId,
                Status = StatusEnum.WaitingToBeAccepted,
                Expert = null
            };
            var check = await _orderService.CheckForDuplicateOffersOfExpert(order.Id,AddOfferDTO.ExpertId, cancellationToken);
            if (check==true)
            {
                throw new Exception("شما قبلا پیشنهاد فرستاده اید");
            }
            var result = await _offerService.Add(AddOfferDTO, cancellationToken);
            await _orderService.Update(order,cancellationToken);
            return result;
        }
        public async Task<List<GetOfferDTO>> GetAll(int id, CancellationToken cancellationToken)
        {
            var result = await _offerService.GetAll(id, cancellationToken);
            return result;
        }
        public async Task<GetOfferDTO> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _offerService.GetById(id, cancellationToken);
            return result;
        }
        public async Task<bool> Update(Offer orderStatusUpdateDTO, CancellationToken cancellationToken)
        {
            var result = await _offerService.Update(orderStatusUpdateDTO, cancellationToken);
            return result;

        }
        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var offer = await _offerService.GetById(id, cancellationToken);
            var result = await _offerService.Delete(id, cancellationToken);
            var order = await _orderService.GetById(offer.OrderId, cancellationToken);
            if (order.Offers.Count==0)
            {
                order.Status = StatusEnum.WaitingForExperts;
                await _orderService.Update(order, cancellationToken);
            }

            return result;
        }
    }
}
