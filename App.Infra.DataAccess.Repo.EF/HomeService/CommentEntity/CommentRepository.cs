using App.Infra.DB.SQLServer.EF;
using HomeService.Domain.Core.HomeService.CategoryEntity.Entities;
using HomeService.Domain.Core.HomeService.CommentEntity.Data;
using HomeService.Domain.Core.HomeService.CommentEntity.DTO;
using HomeService.Domain.Core.HomeService.CommentEntity.Entities;
using HomeService.Domain.Core.HomeService.CustomerEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.OfferEntity.DTO;
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

        public async Task<List<GetCommentDTO>> GetPendings(CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Comments.AsNoTracking().Where(x => x.IsDeleted != true && x.Approved==false).Select(x => new GetCommentDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
               Score = x.Score,
               Approved = x.Approved,
               Customer = x.Customer,
               Expert = x.Expert,
               Offer = x.Offer,
               TimeCreated = x.TimeCreated,
               IsDeleted = x.IsDeleted,
                
            }).ToListAsync(cancellationToken);
            return result;
        }
        public async Task<List<GetCommentDTO>> GetApproved(CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Comments.AsNoTracking().Where(x => x.IsDeleted != true && x.Approved == true).Select(x => new GetCommentDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Score = x.Score,
                Approved = x.Approved,
                Customer = x.Customer,
                Expert = x.Expert,
                Offer = x.Offer,
                TimeCreated = x.TimeCreated,
                IsDeleted = x.IsDeleted,

            }).ToListAsync(cancellationToken);
            return result;
        }
        public async Task<List<GetCommentDTO>> GetDissaproved(CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Comments.AsNoTracking().Where(x => x.IsDeleted != false).Select(x => new GetCommentDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Score = x.Score,
                Approved = x.Approved,
                Customer = x.Customer,
                Expert = x.Expert,
                Offer = x.Offer,
                TimeCreated = x.TimeCreated,
                IsDeleted = x.IsDeleted,

            }).ToListAsync(cancellationToken);
            return result;
        }
        public async Task<GetCommentDTO> GetById(int Id, CancellationToken cancellationToken)
        {
            var result = await _appDbContext.Comments.AsNoTracking().Select(x => new GetCommentDTO
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Score = x.Score,
                Approved = x.Approved,
                Customer = x.Customer,
                Expert = x.Expert,
                Offer = x.Offer,
                TimeCreated = x.TimeCreated,
                IsDeleted = x.IsDeleted,
            }).FirstOrDefaultAsync(x=>x.Id==Id, cancellationToken);
            return result;
        }
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

            com.IsDeleted = comment.IsDeleted;
            com.TimeCreated = comment.TimeCreated;

            _appDbContext.Comments.Update(com);
            await _appDbContext.SaveChangesAsync(cancellationToken);
            return true;

        }
        public async Task<bool> ChangeStatus(UpdateStatusCommentDTO updateStatusCommentDTO, CancellationToken cancellationToken)
        {
            var comment = await _appDbContext.Comments.FirstOrDefaultAsync(x => x.Id == updateStatusCommentDTO.Id, cancellationToken);
            if (comment == null)
            {
                throw new Exception("That Object Does Not Exist");
            }
            comment.Approved= updateStatusCommentDTO.Approved;
            comment.IsDeleted= updateStatusCommentDTO.IsDeleted;

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
