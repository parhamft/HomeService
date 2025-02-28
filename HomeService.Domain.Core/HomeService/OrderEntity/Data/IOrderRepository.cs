using HomeService.Domain.Core.HomeService.OrderEntity.DTO;
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
        Task<List<GetOrderDTO>> GetAll(CancellationToken cancellationToken);
        Task<GetOrderDTO> GetById(int Id, CancellationToken cancellationToken);
        Task<bool> Create(AddOrderDTO order, CancellationToken cancellationToken);
        Task<bool> Update(OrderStatusUpdateDTO order, CancellationToken cancellationToken);
        Task<bool> Delete(int Id, CancellationToken cancellationToken);

    }

}
