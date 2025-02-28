using HomeService.Domain.Core.HomeService.CustomerEntity.DTO;
using HomeService.Domain.Core.HomeService.CustomerEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.CustomerEntity.AppServices
{
    public interface ICustomerAppService
    {
        Task<List<GetCustomerDTO>> GetAll(CancellationToken cancellationToken);
        Task<GetCustomerDTO> GetById(int Id, CancellationToken cancellationToken);
        Task<UpdateCustomerDTO> GetUpdateDTO(int Id, CancellationToken cancellationToken);
        Task<bool> Update(UpdateCustomerDTO customer, CancellationToken cancellationToken);
        Task<bool> Delete(int Id, CancellationToken cancellationToken);
    }
}
