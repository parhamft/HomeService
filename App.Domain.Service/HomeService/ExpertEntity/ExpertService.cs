using HomeService.Domain.Core.HomeService.ExpertEntity.Data;
using HomeService.Domain.Core.HomeService.ExpertEntity.DTO;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service.HomeService.ExpertEntity
{
    public class ExpertService : IExpertService
    {
        private readonly IExpertRepository _expertRepository;

        public ExpertService(IExpertRepository expertRepository)
        {
             _expertRepository = expertRepository;
        }
        public async Task<UpdateExpertDTO> GetUpdate(int id, CancellationToken cancellationToken)
        {
            return await _expertRepository.GetUpdate(id, cancellationToken);
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
