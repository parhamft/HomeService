using HomeService.Domain.Core.HomeService.ServiceEntity.Data;
using HomeService.Domain.Core.HomeService.ServiceEntity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.ServiceEntity.Services
{
    public interface IServiceService
    {
        Task<UpdateServiceDTO> GetUpdate(int Id, CancellationToken cancellationToken);

        Task<List<GetServiceDTO>> GetAll(CancellationToken cancellationToken);
        Task<bool> Delete(int Id, CancellationToken cancellationToken);
        Task<bool> Update(UpdateServiceDTO updateCategoryDTO, CancellationToken cancellationToken);
        Task<bool> Add(AddServiceDTO addCategoryDTO, CancellationToken cancellationToken);
    }
}
