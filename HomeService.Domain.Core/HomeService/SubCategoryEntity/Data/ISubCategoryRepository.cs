using HomeService.Domain.Core.HomeService.SubCategoryEntity.DTO;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.SubCategoryEntity.Data
{
    public interface ISubCategoryRepository
    {
        Task<UpdateSubCategoryDTO> GetUpdate(int Id, CancellationToken cancellationToken);
        Task<List<GetSubCategoryDTO>> GetAll(CancellationToken cancellationToken);
        Task<GetSubCategoryDTO> GetById(int Id, CancellationToken cancellationToken);
        Task<bool> Create(AddSubCategoryDTO subCategory, CancellationToken cancellationToken);
        Task<bool> Update(UpdateSubCategoryDTO subCategory, CancellationToken cancellationToken);
        Task<bool> Delete(int Id, CancellationToken cancellationToken);
    }
}
