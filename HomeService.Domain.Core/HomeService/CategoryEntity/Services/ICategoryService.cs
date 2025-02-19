using HomeService.Domain.Core.HomeService.CategoryEntity.Data;
using HomeService.Domain.Core.HomeService.CategoryEntity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.CategoryEntity.Services
{
    public interface ICategoryService
    {
         Task<UpdateCategoryDTO> GetUpdate(int id, CancellationToken cancellationToken);
         Task<List<GetCategoryWithSubCategoryDTO>> GetEverything(CancellationToken cancellationToken);
         Task<List<GetCategoryDTO>> GetAll(CancellationToken cancellationToken);
         Task<bool> Delete(int Id, CancellationToken cancellationToken);
         Task<bool> Update(UpdateCategoryDTO updateCategoryDTO, CancellationToken cancellationToken);
         Task<bool> Add(AddCategoryDTO addCategoryDTO, CancellationToken cancellationToken);
    }
}
