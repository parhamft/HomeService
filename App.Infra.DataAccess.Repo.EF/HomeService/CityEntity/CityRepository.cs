using App.Infra.DB.SQLServer.EF;
using HomeService.Domain.Core.HomeService.CategoryEntity.Entities;
using HomeService.Domain.Core.HomeService.CityEntity.Data;
using HomeService.Domain.Core.HomeService.CityEntity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repo.EF.HomeService.CityEntity
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _appDbContext;

        public CityRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<City>> GetAll(CancellationToken cancellationToken) => await _appDbContext.Cities.AsNoTracking().ToListAsync(cancellationToken);
        public async Task<City> GetById(int Id, CancellationToken cancellationToken) => await _appDbContext.Cities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
        public async Task<bool> Create(City city, CancellationToken cancellationToken)
        {
            var newCity = new City
            {
                Titel=city.Titel,

            };
            try
            {
                await _appDbContext.Cities.AddAsync(newCity, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> Update(City city, CancellationToken cancellationToken)
        {
            var City = await _appDbContext.Cities.FirstOrDefaultAsync(x => x.Id == city.Id, cancellationToken);
            if (City == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
               City.Titel = city.Titel;



            _appDbContext.Cities.Update(City);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            var city = await _appDbContext.Cities.FirstOrDefaultAsync(x => x.Id == Id);

            if (city == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            _appDbContext.Cities.Remove(city);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
