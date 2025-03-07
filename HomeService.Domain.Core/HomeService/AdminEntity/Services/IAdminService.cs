using HomeService.Domain.Core.HomeService.AdminEntity.Data;
using HomeService.Domain.Core.HomeService.AdminEntity.DTO;
using HomeService.Domain.Core.HomeService.AdminEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.AdminEntity.Services
{
     public interface IAdminService
    {

        Task<List<Admin>> GetAll(CancellationToken cancellationToken);
        Task<Admin> GetById(int Id, CancellationToken cancellationToken);
        Task<UpdateAdminDTO> GetUpdateDTO(int Id, CancellationToken cancellationToken);
        Task<bool> Update(UpdateAdminDTO adminDTO, CancellationToken cancellationToken);
    }
}
