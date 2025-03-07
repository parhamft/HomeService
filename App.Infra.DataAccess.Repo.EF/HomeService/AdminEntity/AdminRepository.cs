using App.Infra.DB.SQLServer.EF;
using HomeService.Domain.Core.HomeService.AdminEntity.Data;
using HomeService.Domain.Core.HomeService.AdminEntity.DTO;
using HomeService.Domain.Core.HomeService.AdminEntity.Entities;
using HomeService.Domain.Core.HomeService.CustomerEntity.DTO;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DataAccess.Repo.EF.HomeService.AdminEntity
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _appDbContext;

        public AdminRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<Admin>> GetAll(CancellationToken cancellationToken) => await _appDbContext.Admins.AsNoTracking().Where(x => x.IsDeleted != true).ToListAsync(cancellationToken);
        public async Task<Admin> GetById(int Id, CancellationToken cancellationToken) => await _appDbContext.Admins.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
        public async Task<bool> Create(Admin admin, CancellationToken cancellationToken)
        {
            var newAdmin = new Admin
            {
                Balance = admin.Balance,
                TimeCreated = admin.TimeCreated,
                UserId = admin.UserId,

            };
            try
            {
                await _appDbContext.Admins.AddAsync(newAdmin, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<UpdateAdminDTO> GetUpdateDTO(int Id, CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Admins.AsNoTracking().Where(x => x.IsDeleted != true &&  x.Id == Id).Select(x => new UpdateAdminDTO
            {
                Id =x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Balance = x.Balance,
                    User = x.User,

            }).FirstOrDefaultAsync( cancellationToken);
            return result;
        }
        public async Task<bool> Update(UpdateAdminDTO adminDTO, CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Admins.AsNoTracking().FirstOrDefaultAsync(x => x.Id == adminDTO.Id, cancellationToken);
            if (result == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            result.FirstName = adminDTO.FirstName;
            result.LastName = adminDTO.LastName;
            result.Balance = adminDTO.Balance;
            result.User = adminDTO.User;

            _appDbContext.Admins.Update(result);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
        public async Task<bool> Delete(int adminId, CancellationToken cancellationToken)
        {
            var admin = await _appDbContext.Admins.FirstOrDefaultAsync(x => x.Id == adminId);

            if (admin == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            _appDbContext.Admins.Remove(admin);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }

    }
}
