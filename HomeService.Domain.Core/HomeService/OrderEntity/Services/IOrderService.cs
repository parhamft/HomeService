using HomeService.Domain.Core.HomeService.OrderEntity.Data;
using HomeService.Domain.Core.HomeService.OrderEntity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.OrderEntity.Services
{
    public interface IOrderService
    {
        Task<bool> Add(AddOrderDTO addOrderDTO, CancellationToken cancellationToken);
        Task<List<GetOrderDTO>> GetAll( CancellationToken cancellationToken);
        Task<GetOrderDTO> GetById(int id, CancellationToken cancellationToken);
        Task<bool> Update(OrderStatusUpdateDTO orderStatusUpdateDTO, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
    }
}
