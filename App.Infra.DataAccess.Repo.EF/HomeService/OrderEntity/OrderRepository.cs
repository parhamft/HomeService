using App.Infra.DB.SQLServer.EF;
using HomeService.Domain.Core.HomeService.CategoryEntity.Entities;
using HomeService.Domain.Core.HomeService.CityEntity.Entities;
using HomeService.Domain.Core.HomeService.CustomerEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.HomeServiceEntity.Entities;
using HomeService.Domain.Core.HomeService.OrderEntity.Data;
using HomeService.Domain.Core.HomeService.OrderEntity.DTO;
using HomeService.Domain.Core.HomeService.OrderEntity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repo.EF.HomeService.OrderEntity
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<GetOrderDTO>> GetAll(CancellationToken cancellationToken)
        {
            var result =  await _appDbContext.Orders.AsNoTracking().Where(x => x.IsDeleted != true).Select(x=> new GetOrderDTO
            {
                Description = x.Description,
                Id = x.Id,
                DateFor = x.DateFor,
                Status = x.Status,

            }
            ).ToListAsync(cancellationToken);
            return result;
        }
        public async Task<GetOrderDTO> GetById(int Id, CancellationToken cancellationToken)
        {

            var result = await _appDbContext.Orders.AsNoTracking().Where(x => x.IsDeleted != true).Select(x => new GetOrderDTO
            {
                Description = x.Description,
                Id = x.Id,
                DateFor = x.DateFor,
                Status = x.Status,
                Customer = x.Customer,
                Expert = x.Expert,
                Service = x.Service,
            }
            ).FirstOrDefaultAsync(x=>x.Id ==Id ,cancellationToken);
            if (result == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            return result;
        }
        public async Task<bool> Create(AddOrderDTO order, CancellationToken cancellationToken)
        {
            var newOrder = new Order
            {
            Description = order.Description,
            CityId = order.CityId,
            CustomerId = order.CustomerId,
            DateFor=order.DateFor,

            ServiceId = order.ServiceId,
            Status = order.Status,
            TimeCreated = order.TimeCreated,

            

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
        public async Task<bool> Update(OrderStatusUpdateDTO order, CancellationToken cancellationToken)
        {
            var ord = await _appDbContext.Orders.FirstOrDefaultAsync(x => x.Id == order.Id, cancellationToken);
            if (ord == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            ord.Status = order.Status;
            ord.Offers = order.Offers;
            ord.Expert = order.Expert;


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
            ord.IsDeleted = true;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
