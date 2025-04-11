using Dapper;
using HomeService.Domain.Core.HomeService.CategoryEntity.Data;
using HomeService.Domain.Core.HomeService.CategoryEntity.DTO;
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
    public class DapperCategoryRepository : IDapperCategoryRepository
    {
        private readonly SiteSettings _siteSettings;

        public DapperCategoryRepository( SiteSettings siteSettings)
        {
            _siteSettings = siteSettings;
        }
        public async Task<List<GetCategoryDTO>> GetAllCategoryDapper(CancellationToken cancellationToken)
        {
            using IDbConnection db = new SqlConnection(_siteSettings.ConnectionStrings.SqlConnection);
            var query = "SELECT Id, Name, ImagePath FROM Categories WHERE IsDeleted = 0";
            var categories = await db.QueryAsync<GetCategoryDTO>(query);
            return categories.ToList();
        }
    }
}
