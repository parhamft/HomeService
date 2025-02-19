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

        public ServiceAppService(IServiceService serviceService)
        {
            _serviceService = serviceService;
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
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _serviceService.Delete(Id, cancellationToken);
            return result;
        }
        public async Task<bool> Update(UpdateServiceDTO updateCategoryDTO, CancellationToken cancellationToken)
        {
            var result = await _serviceService.Update(updateCategoryDTO, cancellationToken);
            return result;
        }
        public async Task<bool> Add(AddServiceDTO addCategoryDTO, CancellationToken cancellationToken)
        {
            var result = await _serviceService.Add(addCategoryDTO, cancellationToken);
            return result;
        }
    }
}
