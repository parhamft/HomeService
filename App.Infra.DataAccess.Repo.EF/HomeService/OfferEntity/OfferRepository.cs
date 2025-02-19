using App.Infra.DB.SQLServer.EF;
using HomeService.Domain.Core.HomeService.CategoryEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.OfferEntity.Data;
using HomeService.Domain.Core.HomeService.OfferEntity.Entities;
using HomeService.Domain.Core.HomeService.OrderEntity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repo.EF.HomeService.OfferEntity
{
    public class OfferRepository : IOfferRepository
    {
        private readonly AppDbContext _appDbContext;

        public OfferRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Offer>> GetAll(CancellationToken cancellationToken) => await _appDbContext.Offers.AsNoTracking().Where(x => x.IsDeleted != true).ToListAsync(cancellationToken);
        public async Task<Offer> GetById(int Id, CancellationToken cancellationToken) => await _appDbContext.Offers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
        public async Task<bool> Create(Offer offer, CancellationToken cancellationToken)
        {
            var newOffer= new Offer
            {
            Description=offer.Description,
            ExpertId=offer.ExpertId,
            OrderId=offer.OrderId,
            Price=offer.Price,
            RequestTime=offer.RequestTime,
            IsDeleted=offer.IsDeleted,
            TimeCreated=offer.TimeCreated,
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
            var off = await _appDbContext.Offers.FirstOrDefaultAsync(x => x.Id == Id);

            if (off == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            _appDbContext.Offers.Remove(off);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
