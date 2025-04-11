using HomeService.Domain.Core.HomeService.CategoryEntity.Data;
using HomeService.Domain.Core.HomeService.CategoryEntity.DTO;
using HomeService.Domain.Core.HomeService.Configs.Data;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.Data;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.DTO;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.HomeService.SubCategoryEntity
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IDapperCategoryRepository _dapperRepo;
        private readonly IDapperSubCategoryRepository _IDapperSubCategoryRepository;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository, IDapperCategoryRepository dapperRepo, IDapperSubCategoryRepository dapperSubCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
            _dapperRepo = dapperRepo;
            _IDapperSubCategoryRepository = dapperSubCategoryRepository;
        }
        public async Task<UpdateSubCategoryDTO> GetUpdate(int id, CancellationToken cancellationToken)
        {
            var cat = await _subCategoryRepository.GetUpdate(id, cancellationToken);
            return cat;
        }

        public async Task<List<GetSubCategoryDTO>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _IDapperSubCategoryRepository.GetAllSubCategoryDapper(cancellationToken);
            return result;
        }
        public async Task<List<GetSubCategoryDTO>> GetAllOfCategory(int Id, CancellationToken cancellationToken)
        {
            var result = await _subCategoryRepository.GetAllOfCategory(Id,cancellationToken);
            return result;
        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _subCategoryRepository.Delete(Id, cancellationToken);
            return result;
        }
        public async Task<bool> Update(UpdateSubCategoryDTO updateCategoryDTO, CancellationToken cancellationToken)
        {
            var result = await _subCategoryRepository.Update(updateCategoryDTO, cancellationToken);
            return result;
        }
        public async Task<bool> Add(AddSubCategoryDTO addCategoryDTO, CancellationToken cancellationToken)
        {
            var result = await _subCategoryRepository.Create(addCategoryDTO, cancellationToken);
            return result;
        }
    }
}
