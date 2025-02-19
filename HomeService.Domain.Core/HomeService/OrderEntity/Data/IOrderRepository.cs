using HomeService.Domain.Core.HomeService.OrderEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.OrderEntity.Data
{
    public interface IOrderRepository
    {
         Task<List<Order>> GetAll(CancellationToken cancellationToken) ;
         Task<Order> GetById(int Id, CancellationToken cancellationToken);
         Task<bool> Create(Order order, CancellationToken cancellationToken);
         Task<bool> Update(Order order, CancellationToken cancellationToken);
         Task<bool> Delete(int Id, CancellationToken cancellationToken);
    }
}
