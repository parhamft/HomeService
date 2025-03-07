using HomeService.Domain.Core.HomeService.CommentEntity.Data;
using HomeService.Domain.Core.HomeService.CommentEntity.DTO;
using HomeService.Domain.Core.HomeService.CommentEntity.Entities;
using HomeService.Domain.Core.HomeService.CommentEntity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Service.HomeService.CommentEntity
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public async Task<List<GetCommentDTO>> GetPendings(CancellationToken cancellationToken)
        {
            return await _commentRepository.GetPendings(cancellationToken);
        }
        public async Task<List<GetCommentDTO>> GetUsersComments(int Id, CancellationToken cancellationToken)
        {
            return await _commentRepository.GetUsersComments(Id, cancellationToken);
        }
        public async Task<List<GetCommentDTO>> GetApproved(CancellationToken cancellationToken)
            {
            return await _commentRepository.GetApproved(cancellationToken);
        }
        public async Task<List<GetCommentDTO>> GetDissaproved(CancellationToken cancellationToken)
            {
            return await _commentRepository.GetDissaproved(cancellationToken);
        }
        public async Task<GetCommentDTO> GetById(int Id, CancellationToken cancellationToken)
            {
            return await _commentRepository.GetById(Id,cancellationToken);
        }
        public async Task<bool> Create(AddCommentDTO comment, CancellationToken cancellationToken)
            {
                return await _commentRepository.Create(comment,cancellationToken);
            }
        public async Task<bool> Update(Comment comment, CancellationToken cancellationToken)
        {
            return await _commentRepository.Update(comment,cancellationToken);
        }
        public async Task<bool> ChangeStatus(UpdateStatusCommentDTO updateStatusCommentDTO, CancellationToken cancellationToken)
        {
            return await _commentRepository.ChangeStatus(updateStatusCommentDTO,cancellationToken);
        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            return await _commentRepository.Delete(Id,cancellationToken);
        }
    }
}
