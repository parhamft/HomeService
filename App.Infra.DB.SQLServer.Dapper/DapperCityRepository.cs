using Dapper;
using HomeService.Domain.Core.HomeService.CityEntity.Data;
using HomeService.Domain.Core.HomeService.CityEntity.Entities;
using HomeService.Domain.Core.HomeService.Configs.Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DB.SQLServer.Dappers
{
    public class DapperCityRepository : IDapperCityRepository
    {
        private readonly SiteSettings _siteSettings;

        public DapperCityRepository(SiteSettings siteSettings)
        {
            _siteSettings = siteSettings;
        }
        public async Task<List<City>> GetAllCityDapper(CancellationToken cancellationToken)
        {
            using IDbConnection db = new SqlConnection(_siteSettings.ConnectionStrings.SqlConnection);
            var query = "SELECT * FROM Cities";
            var cities = await db.QueryAsync<City>(query);
            return cities.ToList();
        }

    }
}
