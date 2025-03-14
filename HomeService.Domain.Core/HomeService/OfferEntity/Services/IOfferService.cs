using HomeService.Domain.Core.HomeService.OfferEntity.Data;
using HomeService.Domain.Core.HomeService.OfferEntity.DTO;
using HomeService.Domain.Core.HomeService.OfferEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.OfferEntity.Services
{
    public interface IOfferService
    {
        Task<bool> Add(AddOfferDTO addOrderDTO, CancellationToken cancellationToken);
        Task<List<GetOfferDTO>> GetAll(int id, CancellationToken cancellationToken);
        Task<GetOfferDTO> GetById(int id, CancellationToken cancellationToken);
        Task<bool> Update(Offer orderStatusUpdateDTO, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
    }
}
