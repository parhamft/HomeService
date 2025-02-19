using HomeService.Domain.Core.HomeService.CategoryEntity.DTO;
using HomeService.Domain.Core.HomeService.CategoryEntity.Entities;
using HomeService.Domain.Core.HomeService.ServiceEntity.DTO;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.CategoryEntity.Data
{
    public interface ICategoryRepository
    {
        Task<UpdateCategoryDTO> GetUpdate(int Id, CancellationToken cancellationToken);
        Task<List<GetCategoryDTO>> GetAll(CancellationToken cancellationToken);
        Task<GetCategoryDTO> GetById(int Id, CancellationToken cancellationToken);
        Task<List<GetCategoryWithSubCategoryDTO>> GetCategoryAndSubCategoryAndService(CancellationToken cancellationToken);
        Task<bool> Create(AddCategoryDTO category, CancellationToken cancellationToken);
        Task<bool> Update(UpdateCategoryDTO category, CancellationToken cancellationToken);
        Task<bool> Delete(int Id, CancellationToken cancellationToken);
    }
}
