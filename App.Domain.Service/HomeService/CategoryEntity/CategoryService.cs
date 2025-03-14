using HomeService.Domain.Core.HomeService.CategoryEntity.Data;
using HomeService.Domain.Core.HomeService.CategoryEntity.DTO;
using HomeService.Domain.Core.HomeService.CategoryEntity.Services;
using HomeService.Domain.Core.HomeService.Configs.Data;
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
        private readonly IDapperRepo _dapper;

        public CategoryService(ICategoryRepository categoryRepository,IDapperRepo Dapper)
        {
            _categoryRepository = categoryRepository;
            _dapper = Dapper;
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
            var result = await _dapper.GetAllCategoryDapper(cancellationToken);
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
