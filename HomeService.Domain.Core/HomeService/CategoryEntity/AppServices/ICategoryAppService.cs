using HomeService.Domain.Core.HomeService.CategoryEntity.DTO;
using HomeService.Domain.Core.HomeService.CategoryEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.CategoryEntity.AppServices
{
    public interface ICategoryAppService
    {
        Task<UpdateCategoryDTO> GetUpdate(int id, CancellationToken cancellationToken);
        Task<List<GetCategoryWithSubCategoryDTO>> GetEverything(CancellationToken cancellationToken);
        Task<List<GetCategoryDTO>> GetAll(CancellationToken cancellationToken);
        Task<bool> Delete(int Id, CancellationToken cancellationToken);
        Task<bool> Update(UpdateCategoryDTO updateCategoryDTO, CancellationToken cancellationToken);
        Task<bool> Add(AddCategoryDTO addCategoryDTO, CancellationToken cancellationToken);
    }
}
