using HomeService.Domain.Core.HomeService.CityEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.CityEntity.Services
{
    public interface ICityService
    {
        Task<List<City>> GetAll(CancellationToken cancellationToken);
    }
}
