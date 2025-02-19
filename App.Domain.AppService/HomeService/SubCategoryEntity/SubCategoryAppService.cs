using HomeService.Domain.Core.HomeService.SubCategoryEntity.AppServices;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.Data;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.DTO;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service.HomeService.SubCategoryEntity
{
    public class SubCategoryAppService : ISubCategoryAppService
    {
        private readonly ISubCategoryService _categoryService;

        public SubCategoryAppService(ISubCategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public async Task<UpdateSubCategoryDTO> GetUpdate(int id, CancellationToken cancellationToken)
        {
            var cat = await _categoryService.GetUpdate(id, cancellationToken);
            return cat;
        }

        public async Task<List<GetSubCategoryDTO>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _categoryService.GetAll(cancellationToken);
            return result;
        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _categoryService.Delete(Id, cancellationToken);
            return result;
        }
        public async Task<bool> Update(UpdateSubCategoryDTO updateCategoryDTO, CancellationToken cancellationToken)
        {
            var result = await _categoryService.Update(updateCategoryDTO, cancellationToken);
            return result;
        }
        public async Task<bool> Add(AddSubCategoryDTO addCategoryDTO, CancellationToken cancellationToken)
        {
            var result = await _categoryService.Add(addCategoryDTO, cancellationToken);
            return result;
        }
    }
}
