using HomeService.Domain.Core.HomeService.AdminEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.AdminEntity.Data
{
    public interface IAdminRepository
    {
        Task<List<Admin>> GetAll(CancellationToken cancellationToken);
         Task<Admin> GetById(int Id, CancellationToken cancellationToken);
         Task<bool> Create(Admin admin, CancellationToken cancellationToken);
         Task<bool> Update(Admin admin, CancellationToken cancellationToken);
         Task<bool> Delete(int adminId, CancellationToken cancellationToken);
    }
}
