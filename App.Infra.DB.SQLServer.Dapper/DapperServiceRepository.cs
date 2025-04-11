using Dapper;
using HomeService.Domain.Core.HomeService.Configs.Entities;
using HomeService.Domain.Core.HomeService.ServiceEntity.Data;
using HomeService.Domain.Core.HomeService.ServiceEntity.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DB.SQLServer.Dappers
{
    public class DapperServiceRepository : IDapperServiceRepository
    {
        private readonly SiteSettings _siteSettings;

        public DapperServiceRepository(SiteSettings siteSettings)
        {
            _siteSettings = siteSettings;
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
