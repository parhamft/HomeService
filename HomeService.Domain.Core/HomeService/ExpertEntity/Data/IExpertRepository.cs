using HomeService.Domain.Core.HomeService.ExpertEntity.DTO;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.ExpertEntity.Data
{
    public interface IExpertRepository
    {
        Task<UpdateExpertDTO> GetUpdate(int id, CancellationToken cancellationToken);
        Task<List<GetExpertDTO>> GetAll(CancellationToken cancellationToken);
        Task<GetExpertDTO> GetById(int Id, CancellationToken cancellationToken);
        Task<bool> Create(Expert expert, CancellationToken cancellationToken);
        Task<bool> Update(UpdateExpertDTO expert, CancellationToken cancellationToken);
        Task<bool> Delete(int Id, CancellationToken cancellationToken);
    }
}
