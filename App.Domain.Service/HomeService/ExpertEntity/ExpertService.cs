using HomeService.Domain.Core.HomeService.ExpertEntity.Data;
using HomeService.Domain.Core.HomeService.ExpertEntity.DTO;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Services;
using HomeService.Domain.Core.HomeService.HomeServiceEntity.Entities;
using HomeService.Domain.Core.HomeService.ServiceEntity.AppServices;
using HomeService.Domain.Core.HomeService.ServiceEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.service.HomeService.ExpertEntity
{
    public class ExpertService : IExpertService
    {
        private readonly IExpertRepository _expertRepository;
        private readonly IServiceService _serviceService;


        public ExpertService(IExpertRepository expertRepository, IServiceService serviceService)
        {
             _expertRepository = expertRepository;
           _serviceService = serviceService;

        }
        public async Task<UpdateExpertDTO> GetUpdate(int Id, CancellationToken cancellationToken)
        {

            var expert = await _expertRepository.GetUpdate(Id, cancellationToken);
            if (expert.services != null)
            {
                foreach (var x in expert.services)
                {
                    expert.servicesId.Add(x.Id);
                }

            }
            return expert;
        }
        public async Task<List<GetExpertDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _expertRepository.GetAll(cancellationToken);
        }
        public async Task<GetExpertDTO> GetById(int Id, CancellationToken cancellationToken)
        {
            return await _expertRepository.GetById(Id, cancellationToken);
        }

        public async Task<bool> Create(Expert expert, CancellationToken cancellationToken)
        {
            return await _expertRepository.Create(expert, cancellationToken);
        }
        public async Task<bool> Update(UpdateExpertDTO expert, CancellationToken cancellationToken)
        {

            return await _expertRepository.Update(expert, cancellationToken);
        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            return await _expertRepository.Delete(Id, cancellationToken);
        }
    }
}
