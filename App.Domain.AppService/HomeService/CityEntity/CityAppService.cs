using HomeService.Domain.Core.HomeService.CityEntity.AppServices;
using HomeService.Domain.Core.HomeService.CityEntity.Entities;
using HomeService.Domain.Core.HomeService.CityEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.HomeService.CityEntity
{
    public class CityAppService : ICityAppService
    {
        private readonly ICityService _cityService;

        public CityAppService(ICityService cityService)
        {
            _cityService = cityService;
        }
        public async Task<List<City>> GetAll(CancellationToken cancellationToken)
        {
            return await _cityService.GetAll(cancellationToken);
        }
    }
}
