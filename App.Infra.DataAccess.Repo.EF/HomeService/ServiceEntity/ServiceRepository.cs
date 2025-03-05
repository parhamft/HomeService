using App.Infra.DB.SQLServer.EF;
using HomeService.Domain.Core.HomeService.CategoryEntity.Entities;
using HomeService.Domain.Core.HomeService.HomeServiceEntity.Entities;
using HomeService.Domain.Core.HomeService.ServiceEntity.Data;
using HomeService.Domain.Core.HomeService.ServiceEntity.DTO;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.DTO;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repo.EF.HomeService.ServiceEntity
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly AppDbContext _appDbContext;

        public ServiceRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<UpdateServiceDTO> GetUpdate(int Id, CancellationToken cancellationToken)
        {
            var cat = await _appDbContext.Services.Where(x=>x.Id==Id).Select(x => new UpdateServiceDTO
            {
                Id = Id,
                BasePrice = x.BasePrice,
                ImagePath = x.ImagePath,
                Name = x.Name,
                SubCategoryId =x.SubCategoryId
                
            }).FirstOrDefaultAsync(x => x.Id == Id);
            return cat;
        }
        public async Task<List<GetServiceDTO>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Services.AsNoTracking().Where(x=>x.IsDeleted==false).Select(x => new GetServiceDTO
            {
                Id= x.Id,
                BasePrice = x.BasePrice,
                SubCategory = x.SubCategory,
                ImagePath = x.ImagePath,
                Name = x.Name
                

            }
            ).ToListAsync(cancellationToken);
            return result;

        }
        public async Task<List<GetServiceDTO>> GetAllSubCategoryOf(int Id,CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Services.AsNoTracking().Where(x => x.IsDeleted == false && x.SubCategoryId == Id).Select(x => new GetServiceDTO
            {
                Id = x.Id,
                BasePrice = x.BasePrice,
                SubCategory = x.SubCategory,
                ImagePath = x.ImagePath,
                Name = x.Name


            }
            ).ToListAsync(cancellationToken);
            return result;

        }
        public async Task<GetServiceDTO> GetById(int Id, CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Services.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
            var cat = new GetServiceDTO
            {
                Id = result.Id,
                BasePrice = result.BasePrice,
                ImagePath = result.ImagePath,
                Name = result.Name
            };
            return cat;
        }
        public async Task<bool> Create(AddServiceDTO service, CancellationToken cancellationToken)
        {
            var newService = new Service
            {
                Name = service.Name,
                BasePrice = service.BasePrice,
                SubCategoryId = service.SubCategoryId,
                ImagePath = service.ImagePath,
                
                TimeCreated = service.TimeCreated,
                

            };
            try
            {
                await _appDbContext.Services.AddAsync(newService, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> Update(UpdateServiceDTO  service, CancellationToken cancellationToken)
        {
            var ser = await _appDbContext.Services.FirstOrDefaultAsync(x => x.Id == service.Id, cancellationToken);
            if (ser == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            ser.Name = service.Name;
            ser.BasePrice = service.BasePrice;
            ser.SubCategoryId = service.SubCategoryId;
            ser.ImagePath = service.ImagePath;


            _appDbContext.Services.Update(ser);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            var ser = await _appDbContext.Services.FirstOrDefaultAsync(x => x.Id == Id);

            if (ser == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            ser.IsDeleted = true;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
