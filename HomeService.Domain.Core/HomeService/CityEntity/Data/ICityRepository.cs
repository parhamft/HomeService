using HomeService.Domain.Core.HomeService.CityEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.CityEntity.Data
{
    public interface ICityRepository
    {
         Task<List<City>> GetAll(CancellationToken cancellationToken);
         Task<City> GetById(int Id, CancellationToken cancellationToken);
         Task<bool> Create(City city, CancellationToken cancellationToken);
         Task<bool> Update(City city, CancellationToken cancellationToken);
         Task<bool> Delete(int Id, CancellationToken cancellationToken);
    };
}
