using HomeService.Domain.Core.HomeService.OfferEntity.AppServices;
using HomeService.Domain.Core.HomeService.OfferEntity.DTO;
using HomeService.Domain.Core.HomeService.OfferEntity.Entities;
using HomeService.Domain.Core.HomeService.OfferEntity.Services;
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

        public OfferAppService(IOfferService offerService)
        {
            _offerService = offerService;
        }
        public async Task<bool> Add(Offer addOrderDTO, CancellationToken cancellationToken)
        {
            var result = await _offerService.Add(addOrderDTO, cancellationToken);
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
            var result = await _offerService.Delete(id, cancellationToken);
            return result;
        }
    }
}
