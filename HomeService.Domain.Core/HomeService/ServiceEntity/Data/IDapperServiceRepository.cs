using HomeService.Domain.Core.HomeService.Configs.Entities;
using HomeService.Domain.Core.HomeService.ServiceEntity.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.ServiceEntity.Data
{
    public interface IDapperServiceRepository
    {
        Task<List<GetServiceDTO>> GetAllServiceDapper(CancellationToken cancellationToken);

    }
}
