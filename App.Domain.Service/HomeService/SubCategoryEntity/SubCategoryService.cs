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
        private readonly IDapperRepo _dapperRepo;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository, IDapperRepo dapperRepo)
        {
            _subCategoryRepository = subCategoryRepository;
            _dapperRepo = dapperRepo;
        }
        public async Task<UpdateSubCategoryDTO> GetUpdate(int id, CancellationToken cancellationToken)
        {
            var cat = await _subCategoryRepository.GetUpdate(id, cancellationToken);
            return cat;
        }

        public async Task<List<GetSubCategoryDTO>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _dapperRepo.GetAllSubCategoryDapper(cancellationToken);
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
