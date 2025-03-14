using HomeService.Domain.Core.HomeService.HomeServiceEntity.Entities;
using HomeService.Domain.Core.HomeService.ServiceEntity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.ServiceEntity.Data
{
    public interface IServiceRepository
    {
        Task<UpdateServiceDTO> GetUpdate(int Id, CancellationToken cancellationToken);
        Task<List<GetServiceDTO>> GetAll(CancellationToken cancellationToken);
        Task<GetServiceDTO> GetById(int Id, CancellationToken cancellationToken);
        Task<bool> Create(AddServiceDTO service, CancellationToken cancellationToken);
        Task<List<Service>> GetAllServices(CancellationToken cancellationToken);
        Task<bool> Update(UpdateServiceDTO service, CancellationToken cancellationToken);
        Task<bool> Delete(int Id, CancellationToken cancellationToken);
        Task<List<GetServiceDTO>> GetAllSubCategoryOf(int Id, CancellationToken cancellationToken);
    }
}
