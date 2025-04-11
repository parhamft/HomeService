using Dapper;
using HomeService.Domain.Core.HomeService.Configs.Entities;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.Data;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DB.SQLServer.Dappers
{
    public class DapperSubCategoryRepository : IDapperSubCategoryRepository
    {
        private readonly SiteSettings _siteSettings;

        public DapperSubCategoryRepository(SiteSettings siteSettings)
        {
            _siteSettings = siteSettings;
        }
        public async Task<List<GetSubCategoryDTO>> GetAllSubCategoryDapper(CancellationToken cancellationToken)
        {
            using IDbConnection db = new SqlConnection(_siteSettings.ConnectionStrings.SqlConnection);
            var query = "SELECT Id, Name, ImagePath, CategoryId FROM SubCategories WHERE IsDeleted = 0";
            var subCategories = await db.QueryAsync<GetSubCategoryDTO>(query);
            return subCategories.ToList();
        }

    }
}
