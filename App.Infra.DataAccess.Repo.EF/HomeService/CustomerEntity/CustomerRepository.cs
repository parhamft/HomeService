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
using HomeService.Domain.Core.HomeService.CommentEntity.DTO;
using HomeService.Domain.Core.HomeService.CustomerEntity.DTO;
using System.Threading;

namespace App.Infra.DataAccess.Repo.EF.HomeService.CustomerEntity
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _appDbContext;

        public CustomerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<GetCustomerDTO>> GetAll(CancellationToken cancellationToken)
        {
            
            var result = await _appDbContext.Customers.AsNoTracking().Where(x => x.IsDeleted != true).Select(x => new GetCustomerDTO
            {
                FirstName= x.FirstName,
                LastName= x.LastName,
                Balance = x.Balance,
                Gender = x.Gender,
                Id= x.Id,
                ImagePath= x.ImagePath,
                TimeCreated= x.TimeCreated,
                User =x.User,
            }).ToListAsync(cancellationToken);
            return result;
        }
        public async Task<GetCustomerDTO> GetById(int Id, CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Customers.AsNoTracking().Where(x => x.IsDeleted != true).Select(x => new GetCustomerDTO
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Balance = x.Balance,
                Gender = x.Gender,
                Id = x.Id,
                ImagePath = x.ImagePath,
                TimeCreated = x.TimeCreated,
                User = x.User,
                Orders = x.Orders,
                Comments = x.Comments.Where(x=>x.Approved==true).ToList(),
            }).FirstOrDefaultAsync(x=>x.Id == Id,cancellationToken);
            return result;
        }
        public async Task<UpdateCustomerDTO> GetUpdateDTO(int Id, CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Customers.AsNoTracking().Where(x => x.IsDeleted != true).Select(x => new UpdateCustomerDTO
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Balance = x.Balance,
                Gender = x.Gender,
                
                Id = x.Id,
                ImagePath = x.ImagePath,

                User = x.User, 
            }).FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
            return result;
        }
        public async Task<bool> Update(UpdateCustomerDTO customer, CancellationToken cancellationToken)
        {
            var cus = await _appDbContext.Customers.AsNoTracking().Include(x=>x.User).FirstOrDefaultAsync(x => x.Id == customer.Id, cancellationToken);
            if (cus == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            cus.FirstName = customer.FirstName;
            cus.LastName = customer.LastName;
            cus.Balance = customer.Balance;
            cus.Gender = customer.Gender;
            cus.User.FullName = $"{customer.FirstName} {customer.LastName}";
            cus.User.Email = customer.User.Email;
            cus.User.UserName = customer.User.Email;
            cus.ImagePath = customer.ImagePath;
            cus.Balance = customer.Balance;
            

            _appDbContext.Customers.Update(cus);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            var ord = await _appDbContext.Customers.FirstOrDefaultAsync(x => x.Id == Id);

            if (ord == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            ord.IsDeleted = true;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }

    }
}
