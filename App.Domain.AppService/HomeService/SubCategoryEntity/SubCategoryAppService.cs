using HomeService.Domain.Core.HomeService.BaseData.Service;
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
        private readonly ISubCategoryService _subCategoryService;
        private readonly IBaseDataService _baseDataService;

        public SubCategoryAppService(ISubCategoryService subCategoryService, IBaseDataService baseDataService)
        {
            _subCategoryService = subCategoryService;
            _baseDataService = baseDataService;
        }


        public async Task<UpdateSubCategoryDTO> GetUpdate(int id, CancellationToken cancellationToken)
        {
            var cat = await _subCategoryService.GetUpdate(id, cancellationToken);
            return cat;
        }

        public async Task<List<GetSubCategoryDTO>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _subCategoryService.GetAll(cancellationToken);
            return result;
        }
        public async Task<List<GetSubCategoryDTO>> GetAllOfCategory(int Id, CancellationToken cancellationToken)
        {
            var result = await _subCategoryService.GetAllOfCategory(Id, cancellationToken);
            return result;
        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _subCategoryService.Delete(Id, cancellationToken);
            return result;
        }
        public async Task<bool> Update(UpdateSubCategoryDTO updateCategoryDTO, CancellationToken cancellationToken)
        {
            var result = await _subCategoryService.Update(updateCategoryDTO, cancellationToken);
            return result;
        }
        public async Task<bool> Add(AddSubCategoryDTO addCategoryDTO, CancellationToken cancellationToken)
        {
            addCategoryDTO.ImagePath = await _baseDataService.UploadImage(addCategoryDTO.ProfileImgFile!, "SubCategory", cancellationToken);
            var result = await _subCategoryService.Add(addCategoryDTO, cancellationToken);
            return result;
        }
    }
}
