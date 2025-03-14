using HomeService.Domain.Core.HomeService.ExpertEntity.DTO;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Services;
using HomeService.Domain.Core.HomeService.OrderEntity.Data;
using HomeService.Domain.Core.HomeService.OrderEntity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.ExpertEntity.AppServices
{
    public interface IExpertAppService
    {
        Task<UpdateExpertDTO> GetUpdate(int id, CancellationToken cancellationToken);
        Task<List<GetExpertDTO>> GetAll(CancellationToken cancellationToken);
        Task<bool> FinishJob(int orderId, CancellationToken cancellationToken);
        Task<GetExpertDTO> GetById(int Id, CancellationToken cancellationToken);
        Task<bool> Create(Expert expert, CancellationToken cancellationToken);
        Task<bool> Update(UpdateExpertDTO expert, CancellationToken cancellationToken);
        Task<bool> UpdateScore(int ExpertId, CancellationToken cancellationToken);
        Task<List<GetOrderDTO>> GetOrdersForExpert(GetExpertDTO getExpertDTO, CancellationToken cancellationToken);
        Task<bool> Delete(int Id, CancellationToken cancellationToken);
    }
}
