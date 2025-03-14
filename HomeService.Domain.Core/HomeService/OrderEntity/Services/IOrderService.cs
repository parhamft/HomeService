using HomeService.Domain.Core.HomeService.OrderEntity.Data;
using HomeService.Domain.Core.HomeService.OrderEntity.DTO;

namespace HomeService.Domain.Core.HomeService.OrderEntity.Services
{
    public interface IOrderService
    {
        Task<bool> Add(AddOrderDTO addOrderDTO, CancellationToken cancellationToken);
        Task<List<GetOrderDTO>> GetAll( CancellationToken cancellationToken);
        Task<GetOrderDTO> GetById(int id, CancellationToken cancellationToken);
        Task<List<GetOrderDTO>> GetAllOfUsers(int id, CancellationToken cancellationToken);
        Task<List<GetOrderDTO>> GetAllAccepted(int ExpertId, CancellationToken cancellationToken);
        Task<List<GetOrderDTO>> GetOrdersForExpert(List<int> Services, int? CityId, CancellationToken cancellationToken);
        Task<bool> CheckForDuplicateOffersOfExpert(int id, int ExpertId, CancellationToken cancellationToken);
        Task<bool> Update(GetOrderDTO getOrderDTO, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
        Task<bool> CheckIfOffersExist(int id, CancellationToken cancellationToken);
        Task<bool> CheckExpert(int id, CancellationToken cancellationToken);
    }
}
