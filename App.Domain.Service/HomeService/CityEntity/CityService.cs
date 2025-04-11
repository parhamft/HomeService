using HomeService.Domain.Core.HomeService.CityEntity.Data;
using HomeService.Domain.Core.HomeService.CityEntity.Entities;
using HomeService.Domain.Core.HomeService.CityEntity.Services;
using HomeService.Domain.Core.HomeService.Configs.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.service.HomeService.CityEntity
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IDapperCityRepository _dapperRepo;

        public CityService(ICityRepository cityRepository, IDapperCityRepository cityEntity)
        {
            _cityRepository = cityRepository;
            _dapperRepo = cityEntity;
        }
        public async Task<List<City>> GetAll(CancellationToken cancellationToken)
        {
            return await _dapperRepo.GetAllCityDapper(cancellationToken);
        }
    }
}
