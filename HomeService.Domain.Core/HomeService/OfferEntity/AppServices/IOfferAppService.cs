using HomeService.Domain.Core.HomeService.OfferEntity.DTO;
using HomeService.Domain.Core.HomeService.OfferEntity.Entities;
using HomeService.Domain.Core.HomeService.OfferEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.OfferEntity.AppServices
{
    public interface IOfferAppService
    {
        Task<bool> Add(AddOfferDTO addOrderDTO, CancellationToken cancellationToken);
        Task<List<GetOfferDTO>> GetAll(int id, CancellationToken cancellationToken);
        Task<GetOfferDTO> GetById(int id, CancellationToken cancellationToken);
        Task<bool> Update(Offer orderStatusUpdateDTO, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
    }
}
