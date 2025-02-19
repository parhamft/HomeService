using HomeService.Domain.Core.HomeService.SubCategoryEntity.Data;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.SubCategoryEntity.Services
{
    public interface ISubCategoryService
    {
        Task<UpdateSubCategoryDTO> GetUpdate(int id, CancellationToken cancellationToken);
        Task<List<GetSubCategoryDTO>> GetAll(CancellationToken cancellationToken);
        Task<bool> Delete(int Id, CancellationToken cancellationToken);
        Task<bool> Update(UpdateSubCategoryDTO updateCategoryDTO, CancellationToken cancellationToken);
        Task<bool> Add(AddSubCategoryDTO addCategoryDTO, CancellationToken cancellationToken);
    }
}
