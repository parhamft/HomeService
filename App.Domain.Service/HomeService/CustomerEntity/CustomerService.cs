using HomeService.Domain.Core.HomeService.CustomerEntity.Data;
using HomeService.Domain.Core.HomeService.CustomerEntity.DTO;
using HomeService.Domain.Core.HomeService.CustomerEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service.HomeService.CustomerEntity
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<List<GetCustomerDTO>> GetAll(CancellationToken cancellationToken)
        {
             return await _customerRepository.GetAll(cancellationToken);
        }
        public async Task<GetCustomerDTO> GetById(int Id, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetById(Id, cancellationToken);
        }
        public async Task<UpdateCustomerDTO> GetUpdateDTO(int Id, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetUpdateDTO(Id, cancellationToken);
        }
        public async Task<bool> Update(UpdateCustomerDTO customer, CancellationToken cancellationToken)
        {
            return await _customerRepository.Update(customer, cancellationToken);
        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            return await _customerRepository.Delete(Id, cancellationToken);
        }
        public async Task<bool> CheckBalance(int Id, decimal amount, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetById(Id, cancellationToken);
            if (customer.Balance>=amount)
            {
                return true;
            }
            return false;
        }
        public async Task<decimal> CalculateTax(decimal amount, CancellationToken cancellationToken)
        {
            return await Task.FromResult(amount * 0.05m);
        }

    }
}
