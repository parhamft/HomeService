using App.Infra.DB.SQLServer.EF;

using HomeService.Domain.Core.HomeService.CustomerEntity.Data;
using HomeService.Domain.Core.HomeService.CategoryEntity.Entities;
using HomeService.Domain.Core.HomeService.CustomerEntity.Entities;
using HomeService.Domain.Core.HomeService.Users.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repo.EF.HomeService.CustomerEntity
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Customer>> GetAll(CancellationToken cancellationToken) => await _appDbContext.Customers.AsNoTracking().Where(x => x.IsDeleted != true).ToListAsync(cancellationToken);
        public async Task<Customer> GetById(int Id, CancellationToken cancellationToken) => await _appDbContext.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
        public async Task<bool> Create(Customer customer, CancellationToken cancellationToken)
        {
            var newCustomer = new Customer
            {
                FirstName =customer.FirstName,
                LastName =customer.LastName,
                Balance = customer.Balance,
                Gender = customer.Gender,
                UserId = customer.UserId,
                ImagePath = customer.ImagePath,
                TimeCreated = customer.TimeCreated,
                IsDeleted = customer.IsDeleted,

            };
            try
            {
                await _appDbContext.Customers.AddAsync(newCustomer, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> Update(Customer customer, CancellationToken cancellationToken)
        {
            var cus = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Id == customer.Id, cancellationToken);
            if (cus == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            cus.FirstName = customer.FirstName;
            cus.LastName = customer.LastName;
            cus.Balance = customer.Balance;
            cus.Gender = customer.Gender;
            cus.UserId = customer.UserId;
            cus.ImagePath = customer.ImagePath;
            cus.TimeCreated = customer.TimeCreated;
            cus.IsDeleted = customer.IsDeleted;

            _appDbContext.Customers.Update(cus);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            var cus = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Id == Id);

            if (cus == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            _appDbContext.Customers.Remove(cus);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
