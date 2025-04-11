using HomeService.Domain.Core.HomeService.BaseData.Service;
using HomeService.Domain.Core.HomeService.CategoryEntity.AppServices;
using HomeService.Domain.Core.HomeService.CategoryEntity.DTO;
using HomeService.Domain.Core.HomeService.CategoryEntity.Entities;
using HomeService.Domain.Core.HomeService.CategoryEntity.Services;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.service.HomeService.CategoryEntity
{
    public class CategoryAppService :ICategoryAppService
    {
        private readonly ICategoryService _categoryService;
        private readonly IBaseDataService _baseDataService;
        private readonly IMemoryCache _memoryCache;

        public CategoryAppService(ICategoryService categoryService, IBaseDataService baseDataService, IMemoryCache memoryCache)
        {
            _categoryService = categoryService;
            _baseDataService = baseDataService;
            _memoryCache = memoryCache;
        }

        public async Task<UpdateCategoryDTO> GetUpdate(int id, CancellationToken cancellationToken)
        {
            var cat = await _categoryService.GetUpdate(id, cancellationToken);
            return cat;
        }

        public async Task<List<GetCategoryWithSubCategoryDTO>> GetEverything(CancellationToken cancellationToken)
        {
            var cats = await _categoryService.GetEverything(cancellationToken);
            return cats;
        }
        public async Task<List<GetCategoryDTO>> GetAll(CancellationToken cancellationToken)
        {

            return await _categoryService.GetAll(cancellationToken);

        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _categoryService.Delete(Id, cancellationToken);
            return result;
        }
        public async Task<bool> Update(UpdateCategoryDTO updateCategoryDTO, CancellationToken cancellationToken)
        {
            if (updateCategoryDTO.ProfileImgFile!=null)
            {
                updateCategoryDTO.ImagePath = await _baseDataService.UploadImage(updateCategoryDTO.ProfileImgFile!, "Category", cancellationToken);
            }
            
            var result = await _categoryService.Update(updateCategoryDTO, cancellationToken);
            return result;
        }
        public async Task<bool> Add(AddCategoryDTO addCategoryDTO, CancellationToken cancellationToken)
        {
            addCategoryDTO.ImagePath = await _baseDataService.UploadImage(addCategoryDTO.ProfileImgFile!, "Category", cancellationToken);
            var result = await _categoryService.Add(addCategoryDTO, cancellationToken);
            return result;
        }
    }
}
 