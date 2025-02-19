using HomeService.Domain.Core.HomeService.ServiceEntity.Data;
using HomeService.Domain.Core.HomeService.ServiceEntity.DTO;
using HomeService.Domain.Core.HomeService.ServiceEntity.Services;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.HomeService.ServiceEntity
{
    public class ServiceService : IServiceService
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceService(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        public async Task<UpdateServiceDTO> GetUpdate(int id, CancellationToken cancellationToken)
        {
            var cat = await _serviceRepository.GetUpdate(id, cancellationToken);
            return cat;
        }

        public async Task<List<GetServiceDTO>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _serviceRepository.GetAll(cancellationToken);
            return result;
        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _serviceRepository.Delete(Id, cancellationToken);
            return result;
        }
        public async Task<bool> Update(UpdateServiceDTO updateCategoryDTO, CancellationToken cancellationToken)
        {
            var result = await _serviceRepository.Update(updateCategoryDTO, cancellationToken);
            return result;
        }
        public async Task<bool> Add(AddServiceDTO addCategoryDTO, CancellationToken cancellationToken)
        {
            var result = await _serviceRepository.Create(addCategoryDTO, cancellationToken);
            return result;
        }
    }
}
