using HomeService.Domain.Core.HomeService.CustomerEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.CustomerEntity.Data
{
    public interface ICustomerRepository
    {
         Task<List<Customer>> GetAll(CancellationToken cancellationToken);
         Task<Customer> GetById(int Id, CancellationToken cancellationToken);
         Task<bool> Create(Customer customer, CancellationToken cancellationToken);
         Task<bool> Update(Customer customer, CancellationToken cancellationToken);
         Task<bool> Delete(int Id, CancellationToken cancellationToken);
    }
}
