using HomeService.Domain.Core.HomeService.CategoryEntity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.CategoryEntity.Data
{
    public interface IDapperCategoryRepository
    {
        Task<List<GetCategoryDTO>> GetAllCategoryDapper(CancellationToken cancellationToken);
    }
}
