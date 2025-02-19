using App.Infra.DB.SQLServer.EF;
using HomeService.Domain.Core.HomeService.CategoryEntity.Entities;
using HomeService.Domain.Core.HomeService.CityEntity.Entities;
using HomeService.Domain.Core.HomeService.CustomerEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.HomeServiceEntity.Entities;
using HomeService.Domain.Core.HomeService.OrderEntity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repo.EF.HomeService.OrderEntity
{
    public class OrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Order>> GetAll(CancellationToken cancellationToken) => await _appDbContext.Orders.AsNoTracking().Where(x => x.IsDeleted != true).ToListAsync(cancellationToken);
        public async Task<Order> GetById(int Id, CancellationToken cancellationToken) => await _appDbContext.Orders.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
        public async Task<bool> Create(Order order, CancellationToken cancellationToken)
        {
            var newOrder = new Order
            {
            Description = order.Description,
            CityId = order.CityId,
            CustomerId = order.CustomerId,
            DateFor=order.DateFor,
            IsDeleted = order.IsDeleted,
            ServiceId = order.ServiceId,
            Status = order.Status,
            TimeCreated = order.TimeCreated,
            ExpertId = order.ExpertId,
            

            };
            try
            {
                await _appDbContext.Orders.AddAsync(newOrder, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> Update(Order order, CancellationToken cancellationToken)
        {
            var ord = await _appDbContext.Orders.FirstOrDefaultAsync(x => x.Id == order.Id, cancellationToken);
            if (ord == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            ord.Description = order.Description;
            ord.CityId = order.CityId;
            ord.CustomerId = order.CustomerId;
            ord.DateFor = order.DateFor;
            ord.IsDeleted = order.IsDeleted;
            ord.ServiceId = order.ServiceId;
            ord.Status = order.Status;
            ord.TimeCreated = order.TimeCreated;
            ord.ExpertId = order.ExpertId;

            _appDbContext.Orders.Update(ord);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            var ord = await _appDbContext.Orders.FirstOrDefaultAsync(x => x.Id == Id);

            if (ord == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            _appDbContext.Orders.Remove(ord);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
