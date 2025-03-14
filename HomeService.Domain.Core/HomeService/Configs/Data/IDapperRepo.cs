using HomeService.Domain.Core.HomeService.CategoryEntity.Data;
using HomeService.Domain.Core.HomeService.CategoryEntity.DTO;
using HomeService.Domain.Core.HomeService.CategoryEntity.Entities;
using HomeService.Domain.Core.HomeService.CityEntity.Entities;
using HomeService.Domain.Core.HomeService.Configs.Entities;
using HomeService.Domain.Core.HomeService.HomeServiceEntity.Entities;
using HomeService.Domain.Core.HomeService.ServiceEntity.DTO;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.DTO;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.Configs.Data
{
    public interface IDapperRepo
    {
        Task<List<City>> GetAllCityDapper(CancellationToken cancellationToken);
        Task<List<GetCategoryDTO>> GetAllCategoryDapper(CancellationToken cancellationToken);
        Task<List<GetSubCategoryDTO>> GetAllSubCategoryDapper(CancellationToken cancellationToken);
        Task<List<GetServiceDTO>> GetAllServiceDapper(CancellationToken cancellationToken);
    }
}
