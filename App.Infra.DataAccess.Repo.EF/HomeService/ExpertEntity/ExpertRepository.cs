using App.Infra.DB.SQLServer.EF;
using HomeService.Domain.Core.HomeService.CityEntity.Entities;
using HomeService.Domain.Core.HomeService.CustomerEntity.DTO;
using HomeService.Domain.Core.HomeService.ExpertEntity.Data;
using HomeService.Domain.Core.HomeService.ExpertEntity.DTO;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Infra.DataAccess.Repo.EF.HomeService.ExpertEntity
{
    public class ExpertRepository: IExpertRepository
    {
        private readonly AppDbContext _appDbContext;

        public ExpertRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<UpdateExpertDTO> GetUpdate(int id,CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Experts
                .AsNoTracking()
                .Include(x=>x.User)

        .Where(x => x.IsDeleted == false && x.Id == id)
                .Select(x => new UpdateExpertDTO
            {
                    Id=x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Balance = x.Balance,
                CityId = x.CityId,
                User =x.User,
                Gender = x.Gender,
                ImagePath = x.ImagePath,
                Rating = x.Rating,

            }).FirstOrDefaultAsync(cancellationToken);
            return result;
        }
        public async Task<List<GetExpertDTO>> GetAll(CancellationToken cancellationToken)
        {

            var result = await _appDbContext.Experts.AsNoTracking().Where(x => x.IsDeleted != true).Select(x => new GetExpertDTO
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Balance = x.Balance,
                Gender = x.Gender,
                Rating = x.Rating,
                Id = x.Id,
                User = x.User,
                ImagePath = x.ImagePath,
                TimeCreated = x.TimeCreated,

            }).ToListAsync(cancellationToken);
            return result;
        }
        public async Task<GetExpertDTO> GetById(int Id, CancellationToken cancellationToken)
        {

            var result = await _appDbContext.Experts.AsNoTracking().Where(x => x.IsDeleted != true).Select(x => new GetExpertDTO
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Balance = x.Balance,
                Gender = x.Gender,
                User = x.User,
                Rating = x.Rating,
                Id = x.Id,
                ImagePath = x.ImagePath,
                TimeCreated = x.TimeCreated,

            }).FirstOrDefaultAsync(x=>x.Id==Id, cancellationToken);
            return result;
        }
        public async Task<bool> Create(Expert expert, CancellationToken cancellationToken)
        {
            var newExpert = new Expert
            {
                FirstName = expert.FirstName,
                LastName = expert.LastName,
                Balance = expert.Balance,
                City = expert.City,
                Gender = expert.Gender,
                ImagePath = expert.ImagePath,
                Rating = expert.Rating,
                UserId = expert.UserId,
                IsDeleted = expert.IsDeleted,
                TimeCreated = expert.TimeCreated,


            };
            try
            {
                await _appDbContext.Experts.AddAsync(newExpert, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> Update(UpdateExpertDTO expert, CancellationToken cancellationToken)
        {
            var exp = await _appDbContext.Experts.Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == expert.Id, cancellationToken);
            if (exp == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            exp.FirstName = expert.FirstName;
            exp.LastName = expert.LastName;
            exp.Balance = expert.Balance;
            exp.CityId = expert.CityId;
            exp.User.Email = expert.User.Email;
            exp.Gender = expert.Gender;
            exp.ImagePath = expert.ImagePath;
            exp.Rating = expert.Rating;
            
            _appDbContext.Experts.Update(exp);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            var exp = await _appDbContext.Experts.FirstOrDefaultAsync(x => x.Id == Id);

            if (exp == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            exp.IsDeleted = true;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
