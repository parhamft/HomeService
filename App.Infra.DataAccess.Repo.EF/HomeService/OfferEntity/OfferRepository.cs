using App.Infra.DB.SQLServer.EF;
using HomeService.Domain.Core.HomeService.OfferEntity.Data;
using HomeService.Domain.Core.HomeService.OfferEntity.DTO;
using HomeService.Domain.Core.HomeService.OfferEntity.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DataAccess.Repo.EF.HomeService.OfferEntity
{
    public class OfferRepository : IOfferRepository
    {
        private readonly AppDbContext _appDbContext;

        public OfferRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<GetOfferDTO>> GetAll(int id, CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Offers.AsNoTracking().Where(x => x.IsDeleted != true && x.Order.Id == id).Select(x => new GetOfferDTO
            {
                Id = x.Id,
                Description = x.Description,
                Price = x.Price,
                RequestTime = x.RequestTime,
                TimeCreated = x.TimeCreated,
                Expert = x.Expert,
                Order = x.Order
            }).ToListAsync(cancellationToken);
            return result;
        }
        public async Task<GetOfferDTO> GetById(int Id, CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Offers.AsNoTracking().Select(x => new GetOfferDTO
            {
                Id = x.Id,
                Description = x.Description,
                Price = x.Price,
                RequestTime = x.RequestTime,
                TimeCreated = x.TimeCreated,
                Expert = x.Expert,
                OrderId= x.OrderId,
                Order = x.Order
            }
                ).FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);

            return result;
        }
        public async Task<bool> Create(Offer offer, CancellationToken cancellationToken)
        {
            var newOffer = new Offer
            {
                Description = offer.Description,
                ExpertId = offer.ExpertId,
                OrderId = offer.OrderId,
                Price = offer.Price,
                RequestTime = offer.RequestTime,
                IsDeleted = offer.IsDeleted,
                TimeCreated = offer.TimeCreated,
            };
            try
            {
                await _appDbContext.Offers.AddAsync(newOffer, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> Update(Offer offer, CancellationToken cancellationToken)
        {
            var off = await _appDbContext.Offers.FirstOrDefaultAsync(x => x.Id == offer.Id, cancellationToken);
            if (off == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            off.Description = offer.Description;
            //off.ExpertId = offer.ExpertId;
            //off.OrderId = offer.OrderId;
            off.Price = offer.Price;
            off.RequestTime = offer.RequestTime;
            off.IsDeleted = offer.IsDeleted;
            off.TimeCreated = offer.TimeCreated;

            _appDbContext.Offers.Update(off);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            var ord = await _appDbContext.Offers.FirstOrDefaultAsync(x => x.Id == Id);

            if (ord == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            ord.IsDeleted = true;

            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
