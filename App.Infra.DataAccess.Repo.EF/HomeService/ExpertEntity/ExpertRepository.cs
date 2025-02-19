using App.Infra.DB.SQLServer.EF;
using HomeService.Domain.Core.HomeService.CityEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Data;
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

        public async Task<List<Expert>> GetAll(CancellationToken cancellationToken) => await _appDbContext.Experts.AsNoTracking().Where(x => x.IsDeleted != true).ToListAsync(cancellationToken);
        public async Task<Expert> GetById(int Id, CancellationToken cancellationToken) => await _appDbContext.Experts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
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
        public async Task<bool> Update(Expert expert, CancellationToken cancellationToken)
        {
            var exp = await _appDbContext.Experts.FirstOrDefaultAsync(x => x.Id == expert.Id, cancellationToken);
            if (exp == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            exp.FirstName = expert.FirstName;
            exp.LastName = expert.LastName;
            exp.Balance = expert.Balance;
            exp.City = expert.City;
            exp.Gender = expert.Gender;
            exp.ImagePath = expert.ImagePath;
            exp.Rating = expert.Rating;
            exp.UserId = expert.UserId;
            exp.IsDeleted = expert.IsDeleted;
            exp.TimeCreated = expert.TimeCreated;

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
            _appDbContext.Experts.Remove(exp);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
