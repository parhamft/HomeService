using HomeService.Domain.Core.HomeService.CityEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.CityEntity.AppServices
{
    public interface ICityAppService
    {
        Task<List<City>> GetAll(CancellationToken cancellationToken);
    }
}
