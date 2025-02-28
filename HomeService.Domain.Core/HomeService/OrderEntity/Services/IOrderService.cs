using HomeService.Domain.Core.HomeService.OrderEntity.DTO;

namespace HomeService.Domain.Core.HomeService.OrderEntity.Services
{
    public interface IOrderService
    {
        Task<bool> Add(AddOrderDTO addOrderDTO, CancellationToken cancellationToken);
        Task<List<GetOrderDTO>> GetAll( CancellationToken cancellationToken);
        Task<GetOrderDTO> GetById(int id, CancellationToken cancellationToken);
        Task<bool> Update(GetOrderDTO getOrderDTO, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
        Task<bool> CheckIfOffersExist(int id, CancellationToken cancellationToken);
        Task<bool> CheckExpert(int id, CancellationToken cancellationToken);
    }
}
