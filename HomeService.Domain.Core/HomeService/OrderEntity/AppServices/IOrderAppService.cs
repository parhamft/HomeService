using HomeService.Domain.Core.HomeService.OfferEntity.DTO;
using HomeService.Domain.Core.HomeService.OrderEntity.DTO;
using HomeService.Domain.Core.HomeService.OrderEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.OrderEntity.AppServices
{
    public interface IOrderAppService
    {
        Task<bool> Add(AddOrderDTO addOrderDTO, CancellationToken cancellationToken);
        Task<List<GetOrderDTO>> GetAll(CancellationToken cancellationToken);
        Task<GetOrderDTO> GetById(int id, CancellationToken cancellationToken);
        Task<List<GetOrderDTO>> GetAllOfUsers(int id, CancellationToken cancellationToken);
        Task<bool> Update(GetOfferDTO getOfferDTO, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
        Task<bool> ChangeStatus(int id, int status, CancellationToken cancellationToken);
    }
}
