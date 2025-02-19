using HomeService.Domain.Core.HomeService.CategoryEntity.Data;
using HomeService.Domain.Core.HomeService.CategoryEntity.DTO;
using HomeService.Domain.Core.HomeService.CategoryEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.HomeService.CategoryEntity
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }



        public async Task<UpdateCategoryDTO> GetUpdate(int id, CancellationToken cancellationToken)
        {
            var cat = await _categoryRepository.GetUpdate(id,cancellationToken);
            return cat;
        }

        public async Task<List<GetCategoryWithSubCategoryDTO>> GetEverything(CancellationToken cancellationToken)
        {
            var cats = await _categoryRepository.GetCategoryAndSubCategoryAndService(cancellationToken);
            return cats;
        }
        public async Task<List<GetCategoryDTO>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetAll(cancellationToken);
            return result;
        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
             var result = await _categoryRepository.Delete(Id, cancellationToken);
            return result;
        }
        public async Task<bool> Update(UpdateCategoryDTO updateCategoryDTO, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.Update(updateCategoryDTO, cancellationToken);
            return result;
        }
        public async Task<bool> Add(AddCategoryDTO addCategoryDTO, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.Create(addCategoryDTO, cancellationToken);
            return result;
        }
    }
}
