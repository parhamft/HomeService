using HomeService.Domain.Core.HomeService.AdminEntity.AppServices;
using HomeService.Domain.Core.HomeService.AdminEntity.Services;
using HomeService.Domain.Core.HomeService.BaseData.Service;
using HomeService.Domain.Core.HomeService.CustomerEntity.AppServices;
using HomeService.Domain.Core.HomeService.CustomerEntity.Data;
using HomeService.Domain.Core.HomeService.CustomerEntity.DTO;
using HomeService.Domain.Core.HomeService.CustomerEntity.Services;
using HomeService.Domain.Core.HomeService.ExpertEntity.AppServices;
using HomeService.Domain.Core.HomeService.OrderEntity.AppServices;
using HomeService.Domain.Core.HomeService.OrderEntity.Enums;
using HomeService.Domain.Core.HomeService.OrderEntity.Services;
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
        private readonly IOrderService _orderAppService;
        private readonly IExpertAppService _expertAppService;
        private readonly IAdminService _adminService;
        private readonly IBaseDataService _baseDataService;

        public CustomerAppService(ICustomerService customerRepository,IBaseDataService baseDataService, IOrderService orderAppService,IExpertAppService expertAppService,IAdminService adminService)
        {
            _customerService = customerRepository;
            _baseDataService = baseDataService;
            _orderAppService = orderAppService;
            _expertAppService = expertAppService;
            _adminService = adminService;
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
        public async Task<bool> Transaction(int OrderId,decimal amount,CancellationToken cancellationToken)
        {
            var order = await _orderAppService.GetById(OrderId, cancellationToken);
            var Customer = await _customerService.GetUpdateDTO(order.Customer.Id,cancellationToken);
            var Expert = await _expertAppService.GetUpdate(order.Expert.Id, cancellationToken);
            var Admin = await _adminService.GetUpdateDTO(1, cancellationToken);
            var result = await _customerService.CheckBalance(Customer.Id, amount, cancellationToken);
            if (result==false)
            { return false; }
            var tax = await _customerService.CalculateTax(amount, cancellationToken);
            Customer.Balance -= amount + tax;
            await _customerService.Update(Customer, cancellationToken);
            Expert.Balance += amount;
            await _expertAppService.Update(Expert, cancellationToken);
            Admin.Balance += tax;
            await _adminService.Update(Admin, cancellationToken);

            return true;


        }
    }
}
