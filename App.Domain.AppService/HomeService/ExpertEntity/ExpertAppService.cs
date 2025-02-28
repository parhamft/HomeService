using HomeService.Domain.Core.HomeService.ExpertEntity.AppServices;
using HomeService.Domain.Core.HomeService.ExpertEntity.DTO;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.HomeService.ExpertEntity
{
    public class ExpertAppService : IExpertAppService
    {
        private readonly IExpertService _expertService;

        public ExpertAppService(IExpertService expertService)
        {
            _expertService = expertService;
        }
        public async Task<UpdateExpertDTO> GetUpdate(int id, CancellationToken cancellationToken)
        {
            return await _expertService.GetUpdate(id, cancellationToken);
        }
        public async Task<List<GetExpertDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _expertService.GetAll(cancellationToken);
        }
        public async Task<GetExpertDTO> GetById(int Id, CancellationToken cancellationToken)
        {
            return await _expertService.GetById(Id, cancellationToken);
        }
        public async Task<bool> Create(Expert expert, CancellationToken cancellationToken)
        {
            return await _expertService.Create(expert, cancellationToken);
        }
        public async Task<bool> Update(UpdateExpertDTO expert, CancellationToken cancellationToken)
        {
            return await _expertService.Update(expert, cancellationToken);
        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            return await _expertService.Delete(Id, cancellationToken);
        }
    }
}
