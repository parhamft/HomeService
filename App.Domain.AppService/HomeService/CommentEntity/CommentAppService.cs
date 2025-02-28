using HomeService.Domain.Core.HomeService.CommentEntity.AppServices;
using HomeService.Domain.Core.HomeService.CommentEntity.Data;
using HomeService.Domain.Core.HomeService.CommentEntity.DTO;
using HomeService.Domain.Core.HomeService.CommentEntity.Entities;
using HomeService.Domain.Core.HomeService.CommentEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.HomeService.CommentEntity
{
    public class CommentAppService : IcommentAppService
    {
        private readonly ICommentService _commentService;

        public CommentAppService(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public async Task<List<GetCommentDTO>> GetPendings(CancellationToken cancellationToken)
        {
            return await _commentService.GetPendings(cancellationToken);
        }
        public async Task<List<GetCommentDTO>> GetApproved(CancellationToken cancellationToken)
        {
            return await _commentService.GetApproved(cancellationToken);
        }
        public async Task<List<GetCommentDTO>> GetDissaproved(CancellationToken cancellationToken)
        {
            return await _commentService.GetDissaproved(cancellationToken);
        }
        public async Task<GetCommentDTO> GetById(int Id, CancellationToken cancellationToken)
        {
            return await _commentService.GetById(Id, cancellationToken);
        }
        public async Task<bool> Create(Comment comment, CancellationToken cancellationToken)
        {
            return await _commentService.Create(comment, cancellationToken);
        }
        public async Task<bool> Update(Comment comment, CancellationToken cancellationToken)
        {
            return await _commentService.Update(comment, cancellationToken);
        }
        public async Task<bool> ChangeStatus(int commentId,int actionId, CancellationToken cancellationToken)
        {
            var comment = new UpdateStatusCommentDTO
            {
                Id = commentId,

            };
            if (actionId == 1)
            {
                comment.Approved = true;
            }
            else if (actionId == 2) 
            {
                comment.IsDeleted = true;
            }
            return await _commentService.ChangeStatus(comment, cancellationToken);
        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            return await _commentService.Delete(Id, cancellationToken);
        }
    }
}
