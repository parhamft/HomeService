using App.Infra.DB.SQLServer.EF;
using HomeService.Domain.Core.HomeService.CategoryEntity.Entities;
using HomeService.Domain.Core.HomeService.CommentEntity.Data;
using HomeService.Domain.Core.HomeService.CommentEntity.Entities;
using HomeService.Domain.Core.HomeService.CustomerEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.OfferEntity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataAccess.Repo.EF.HomeService.CommentEntity
{
    public class CommentRepository: ICommentRepository
    {
        private readonly AppDbContext _appDbContext;

        public CommentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Comment>> GetAll(CancellationToken cancellationToken) => await _appDbContext.Comments.AsNoTracking().Where(x => x.IsDeleted != true).ToListAsync(cancellationToken);
        public async Task<Comment> GetById(int Id, CancellationToken cancellationToken) => await _appDbContext.Comments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id, cancellationToken);
        public async Task<bool> Create(Comment comment, CancellationToken cancellationToken)
        {
            var newComment = new Comment
            {
                Title = comment.Title,
                Score = comment.Score,
                Description = comment.Description,
                Approved = comment.Approved,
                CustomerId = comment.CustomerId,
                ExpertId = comment.ExpertId,
                OfferId = comment.OfferId,
                IsDeleted = comment.IsDeleted,
                TimeCreated = comment.TimeCreated,

            };
            try
            {
                await _appDbContext.Comments.AddAsync(newComment, cancellationToken);
                await _appDbContext.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> Update(Comment comment, CancellationToken cancellationToken)
        {
            var com = await _appDbContext.Comments.FirstOrDefaultAsync(x => x.Id == comment.Id, cancellationToken);
            if (com == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            com.Title = comment.Title;
            com.Score = comment.Score;
            com.Description = comment.Description;
            com.Approved = comment.Approved;
            //com.CustomerId = comment.CustomerId;
            //com.ExpertId = comment.ExpertId;
            //com.OfferId = comment.OfferId;
            com.IsDeleted = comment.IsDeleted;
            com.TimeCreated = comment.TimeCreated;

            _appDbContext.Comments.Update(com);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            var com = await _appDbContext.Comments.FirstOrDefaultAsync(x => x.Id == Id);

            if (com == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            _appDbContext.Comments.Remove(com);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
    }
}
