using App.Infra.DB.SQLServer.EF;
using HomeService.Domain.Core.HomeService.CategoryEntity.DTO;
using HomeService.Domain.Core.HomeService.CategoryEntity.Entities;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.Data;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.DTO;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repo.EF.HomeService.SubCategoryEntity
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public SubCategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<UpdateSubCategoryDTO> GetUpdate(int Id, CancellationToken cancellationToken)
        {
            var cat = await _appDbContext.SubCategories.Select(x => new UpdateSubCategoryDTO
            {
                Id = x.Id,
                Name = x.Name,
                ImagePath = x.ImagePath,
                CategoryId =x.CategoryId
                
            }).FirstOrDefaultAsync(x=>x.Id==Id);
            return cat;
        }
        public async Task<List<GetSubCategoryDTO>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _appDbContext.SubCategories.AsNoTracking().Where(x=>x.IsDeleted!=true).Select(x => new GetSubCategoryDTO
            {
                Id = x.Id,
                Name = x.Name,
                CategoryId= x.CategoryId,
                ImagePath = x.ImagePath,
                Category = x.Category
                

            }
            ).ToListAsync(cancellationToken);
            return result;

        }
        public async Task<GetSubCategoryDTO> GetById(int Id, CancellationToken cancellationToken)
        {
            var result = await _appDbContext.SubCategories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
            var cat = new GetSubCategoryDTO
            {
                Id = result.Id,
                Name = result.Name,
                CategoryId = result.CategoryId,
                ImagePath = result.ImagePath
            };
            return cat;
        }
        public async Task<bool> Create(AddSubCategoryDTO subCategory, CancellationToken cancellationToken)
        {
            var newsub = new SubCategory
            {
            Name = subCategory.Name,
            CategoryId = subCategory.CategoryId,
            ImagePath = subCategory.ImagePath,

            TimeCreated = subCategory.TimeCreated,
            

            };
            try
            {
                await _appDbContext.SubCategories.AddAsync(newsub, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> Update(UpdateSubCategoryDTO subCategory, CancellationToken cancellationToken)
        {
            var sub = await _appDbContext.SubCategories.FirstOrDefaultAsync(x => x.Id == subCategory.Id, cancellationToken);
            if (sub == null)
            {
                throw new Exception("That Object Does Not Exist");
            }

            sub.Name = subCategory.Name;
            sub.ImagePath = subCategory.ImagePath;
            sub.CategoryId = subCategory.CategoryId;

            

            _appDbContext.SubCategories.Update(sub);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            var sub = await _appDbContext.SubCategories.FirstOrDefaultAsync(x => x.Id == Id);

            if (sub == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            sub.IsDeleted = true;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
