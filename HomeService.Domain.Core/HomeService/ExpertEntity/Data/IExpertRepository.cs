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
         Task<List<Expert>> GetAll(CancellationToken cancellationToken);
         Task<Expert> GetById(int Id, CancellationToken cancellationToken);
         Task<bool> Create(Expert expert, CancellationToken cancellationToken);
         Task<bool> Update(Expert expert, CancellationToken cancellationToken);
         Task<bool> Delete(int Id, CancellationToken cancellationToken);
    }
}
