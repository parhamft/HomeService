using HomeService.Domain.Core.HomeService.OfferEntity.DTO;
using HomeService.Domain.Core.HomeService.OfferEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.OfferEntity.Data
{
    public interface IOfferRepository
    {
        Task<List<GetOfferDTO>> GetAll(int id, CancellationToken cancellationToken);
        Task<GetOfferDTO> GetById(int Id, CancellationToken cancellationToken);
        Task<bool> Create(Offer offer, CancellationToken cancellationToken);
        Task<bool> Update(Offer offer, CancellationToken cancellationToken);
        Task<bool> Delete(int Id, CancellationToken cancellationToken);
    }
}

