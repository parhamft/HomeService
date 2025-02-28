using App.Infra.DB.SQLServer.EF;
using HomeService.Domain.Core.HomeService.ImageEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repo.EF.HomeService
{
    public class ImageRepository
    {
        private readonly AppDbContext _appDbContext;

        public ImageRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> Create(Image image, CancellationToken cancellationToken)
        {
            var newImage = new Image { Id = image.Id, ImagePath = image.ImagePath, OrderId = image.OrderId };
            await _appDbContext.AddAsync(newImage);
            return true;

        }
        public async Task<List<Image>> GetAll(int Id ,CancellationToken cancellationToken) => await  _appDbContext.Images.AsNoTracking().Where(x=>x.OrderId == Id).ToListAsync();

    }
}
