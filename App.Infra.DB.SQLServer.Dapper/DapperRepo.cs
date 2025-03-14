using Dapper;
using HomeService.Domain.Core.HomeService.CategoryEntity.DTO;
using HomeService.Domain.Core.HomeService.CategoryEntity.Entities;
using HomeService.Domain.Core.HomeService.CityEntity.Entities;
using HomeService.Domain.Core.HomeService.Configs.Data;
using HomeService.Domain.Core.HomeService.Configs.Entities;
using HomeService.Domain.Core.HomeService.HomeServiceEntity.Entities;
using HomeService.Domain.Core.HomeService.ServiceEntity.DTO;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.DTO;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DB.SQLServer.Dappers
{
    public class DapperRepo : IDapperRepo
    {
        private readonly SiteSettings _siteSettings;
        private readonly IMemoryCache _memoryCache;

        public DapperRepo(SiteSettings siteSettings)
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

        public async Task<List<GetCategoryDTO>> GetAllCategoryDapper(CancellationToken cancellationToken)
        {
            using IDbConnection db = new SqlConnection(_siteSettings.ConnectionStrings.SqlConnection);
            var query = "SELECT Id, Name, ImagePath FROM Categories WHERE IsDeleted = 0";
            var categories = await db.QueryAsync<GetCategoryDTO>(query);
            return categories.ToList();
        }

        public async Task<List<GetSubCategoryDTO>> GetAllSubCategoryDapper(CancellationToken cancellationToken)
        {
            using IDbConnection db = new SqlConnection(_siteSettings.ConnectionStrings.SqlConnection);
            var query = "SELECT Id, Name, ImagePath, CategoryId FROM SubCategories WHERE IsDeleted = 0";
            var subCategories = await db.QueryAsync<GetSubCategoryDTO>(query);
            return subCategories.ToList();
        }

        public async Task<List<GetServiceDTO>> GetAllServiceDapper(CancellationToken cancellationToken)
        {
            using IDbConnection db = new SqlConnection(_siteSettings.ConnectionStrings.SqlConnection);

            var query = "SELECT * FROM Services WHERE IsDeleted = 0";
            var services = await db.QueryAsync(query);

            return services.Select(s => new GetServiceDTO
            {
                Id = s.Id,
                Name = s.Name,
                ImagePath = s.ImagePath,
                SubCategoryId = s.SubCategoryId,
                BasePrice = s.BasePrice,

            }).ToList();
        }

    }
}
