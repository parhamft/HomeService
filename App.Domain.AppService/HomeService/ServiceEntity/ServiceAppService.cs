using HomeService.Domain.Core.HomeService.BaseData.Service;
using HomeService.Domain.Core.HomeService.CategoryEntity.DTO;
using HomeService.Domain.Core.HomeService.ServiceEntity.AppServices;
using HomeService.Domain.Core.HomeService.ServiceEntity.Data;
using HomeService.Domain.Core.HomeService.ServiceEntity.DTO;
using HomeService.Domain.Core.HomeService.ServiceEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service.HomeService.ServiceEntity
{
    public class ServiceAppService : IServiceAppService
    {
        private readonly IServiceService _serviceService;
        private readonly IBaseDataService _baseDataService;

        public ServiceAppService(IServiceService serviceService,IBaseDataService baseDataService)
        {
            _serviceService = serviceService;
            _baseDataService = baseDataService;
        }

        public async Task<UpdateServiceDTO> GetUpdate(int id, CancellationToken cancellationToken)
        {
            var cat = await _serviceService.GetUpdate(id, cancellationToken);
            return cat;
        }

        public async Task<List<GetServiceDTO>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _serviceService.GetAll(cancellationToken);
            return result;
        }
        public async Task<List<GetServiceDTO>> GetAllSubCategoryOf(int Id, CancellationToken cancellationToken)
        {
            var result = await _serviceService.GetAllSubCategoryOf(Id, cancellationToken);
            return result;
        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _serviceService.Delete(Id, cancellationToken);
            return result;
        }
        public async Task<bool> Update(UpdateServiceDTO updateServiceDTO, CancellationToken cancellationToken)
        {
            if (updateServiceDTO.ProfileImgFile != null)
            {
                updateServiceDTO.ImagePath = await _baseDataService.UploadImage(updateServiceDTO.ProfileImgFile!, "Services", cancellationToken);
            }
            var result = await _serviceService.Update(updateServiceDTO, cancellationToken);
            return result;
        }
        public async Task<bool> Add(AddServiceDTO addServiceDTO, CancellationToken cancellationToken)
        {

            addServiceDTO.ImagePath = await _baseDataService.UploadImage(addServiceDTO.ProfileImgFile!, "Services", cancellationToken);
            var result = await _serviceService.Add(addServiceDTO, cancellationToken);
            return result;
        }
    }
}
