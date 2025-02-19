using App.Infra.DB.SQLServer.EF;
using HomeService.Domain.Core.HomeService.CategoryEntity.Entities;
using HomeService.Domain.Core.HomeService.UserEntity.Data;
using HomeService.Domain.Core.HomeService.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repo.EF.HomeService.UserEntity
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<User>> GetAll(CancellationToken cancellationToken) => await _appDbContext.Users.AsNoTracking().ToListAsync(cancellationToken);
        public async Task<User> GetById(int Id, CancellationToken cancellationToken) => await _appDbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
        public async Task<bool> Create(User user, CancellationToken cancellationToken)
        {
            var newUser = new User
            {
                Email = user.Email,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                PasswordHash = user.PasswordHash,
                ConcurrencyStamp = user.ConcurrencyStamp,
                NormalizedUserName = user.NormalizedUserName,
                NormalizedEmail = user.NormalizedEmail,
                SecurityStamp = user.SecurityStamp,
                

            };
            try
            {
                await _appDbContext.Users.AddAsync(newUser, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> Update(User user, CancellationToken cancellationToken)
        {
            var oldUser = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id, cancellationToken);
            if (oldUser == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            oldUser.Email = user.Email;
            oldUser.UserName = user.UserName;
            oldUser.PhoneNumber = user.PhoneNumber;
            oldUser.PasswordHash = user.PasswordHash;
            oldUser.ConcurrencyStamp = user.ConcurrencyStamp;
            oldUser.NormalizedUserName = user.NormalizedUserName;
            oldUser.NormalizedEmail = user.NormalizedEmail;
            oldUser.SecurityStamp = user.SecurityStamp;

            _appDbContext.Users.Update(oldUser);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            var oldUser = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == Id);

            if (oldUser == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            _appDbContext.Users.Remove(oldUser);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
