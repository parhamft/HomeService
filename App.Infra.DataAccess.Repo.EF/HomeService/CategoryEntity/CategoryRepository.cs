using App.Infra.DB.SQLServer.EF;
using HomeService.Domain.Core.HomeService.AdminEntity.Entities;
using HomeService.Domain.Core.HomeService.CategoryEntity.Data;
using HomeService.Domain.Core.HomeService.CategoryEntity.DTO;
using HomeService.Domain.Core.HomeService.CategoryEntity.Entities;
using HomeService.Domain.Core.HomeService.ServiceEntity.DTO;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repo.EF.HomeService.CategoryEntity
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

    
        public async Task<UpdateCategoryDTO> GetUpdate(int Id, CancellationToken cancellationToken)
        {
            var cat = await _appDbContext.Categories.Select(x => new UpdateCategoryDTO
            {
                Id = x.Id,
                Name = x.Name,
                ImagePath = x.ImagePath
            }).FirstOrDefaultAsync(x=>x.Id==Id);
            return cat;
        }
        public async Task<List<GetCategoryDTO>> GetAll(CancellationToken cancellationToken)
        {
             var result = await _appDbContext.Categories.AsNoTracking().Select(x=> new GetCategoryDTO
             {
                 Id = x.Id,
                 Name = x.Name,
                 ImagePath = x.ImagePath

             }
             ).ToListAsync(cancellationToken);
            return result;
            
        }

        public async Task<GetCategoryDTO> GetById(int Id, CancellationToken cancellationToken)
        {
            var result =  await _appDbContext.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
            var cat = new GetCategoryDTO
            {
                Id = result.Id,
                 Name = result.Name,
                ImagePath = result.ImagePath
            };
            return cat;
        }
        public async Task<List<GetCategoryWithSubCategoryDTO>> GetCategoryAndSubCategoryAndService(CancellationToken cancellationToken)
        {
            var category = await _appDbContext.Categories.Select(x => new GetCategoryWithSubCategoryDTO
            {
                Id = x.Id,
                Name = x.Name,
                ImagePath = x.ImagePath,
                SubCategories = x.SubCategories.Select(z => new GetSubCategoryWithServiceDTO
                {
                    Id = z.Id,
                    Name = z.Name,
                    ImagePath = z.ImagePath,
                    CategoryId = z.CategoryId,
                    Services = z.Services.Select(a => new GetServiceDTO
                    {
                        Id = a.Id,
                        Name = a.Name,
                        ImagePath = a.ImagePath,
                        BasePrice = a.BasePrice,
                        SubCategoryId = a.SubCategoryId
                    }).ToList()
                }).ToList()


            }
            ).ToListAsync();
            return category;
        }
        
        public async Task<bool> Create(AddCategoryDTO category, CancellationToken cancellationToken)
        {
            var newCategory= new Category
            {
                Name = category.Name,
                ImagePath = category.ImagePath,
                TimeCreated = category.TimeCreated,
                
            };
            try
            {
                await _appDbContext.Categories.AddAsync(newCategory, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> Update(UpdateCategoryDTO category, CancellationToken cancellationToken)
        {
            var Cat = await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Id == category.Id, cancellationToken);
            if (Cat == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            Cat.Name =category.Name;
            Cat.ImagePath = category.ImagePath;

            _appDbContext.Categories.Update(Cat);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            var Cat = await _appDbContext.Categories.FirstOrDefaultAsync(x => x.Id == Id);

            if (Cat == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            Cat.IsDeleted = true;
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }

    }
}
