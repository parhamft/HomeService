using HomeService.Domain.Core.HomeService.BaseData.Service;
using HomeService.Domain.Core.HomeService.CustomerEntity.AppServices;
using HomeService.Domain.Core.HomeService.CustomerEntity.Data;
using HomeService.Domain.Core.HomeService.CustomerEntity.DTO;
using HomeService.Domain.Core.HomeService.CustomerEntity.Services;
using HomeService.Domain.Core.HomeService.ServiceEntity.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.HomeService.CustomerEntity
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _customerService;
        private readonly IBaseDataService _baseDataService;

        public CustomerAppService(ICustomerService customerRepository,IBaseDataService baseDataService)
        {
            _customerService = customerRepository;
            _baseDataService = baseDataService;
        }
        public async Task<List<GetCustomerDTO>> GetAll(CancellationToken cancellationToken)
        {
            return await _customerService.GetAll(cancellationToken);
        }
        public async Task<GetCustomerDTO> GetById(int Id, CancellationToken cancellationToken)
        {
            return await _customerService.GetById(Id, cancellationToken);
        }
        public async Task<UpdateCustomerDTO> GetUpdateDTO(int Id, CancellationToken cancellationToken)
        {
            return await _customerService.GetUpdateDTO(Id, cancellationToken);
        }
        public async Task<bool> Update(UpdateCustomerDTO customer, CancellationToken cancellationToken)
        {
            if (customer.ProfileImgFile != null)
            {
                customer.ImagePath = await _baseDataService.UploadImage(customer.ProfileImgFile!, "Users", cancellationToken);
            }
            return await _customerService.Update(customer, cancellationToken);
        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            return await _customerService.Delete(Id, cancellationToken);
        }
    }
}
