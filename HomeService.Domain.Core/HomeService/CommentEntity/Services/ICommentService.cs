using HomeService.Domain.Core.HomeService.CommentEntity.Data;
using HomeService.Domain.Core.HomeService.CommentEntity.DTO;
using HomeService.Domain.Core.HomeService.CommentEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.CommentEntity.Services
{
    public interface ICommentService
    {
        Task<List<GetCommentDTO>> GetPendings(CancellationToken cancellationToken);
        Task<List<GetCommentDTO>> GetApproved(CancellationToken cancellationToken);
        Task<List<GetCommentDTO>> GetDissaproved(CancellationToken cancellationToken);
        Task<GetCommentDTO> GetById(int Id, CancellationToken cancellationToken);
        Task<bool> Create(Comment comment, CancellationToken cancellationToken);
        Task<bool> Update(Comment comment, CancellationToken cancellationToken);
        Task<bool> ChangeStatus(UpdateStatusCommentDTO updateStatusCommentDTO, CancellationToken cancellationToken);
        Task<bool> Delete(int Id, CancellationToken cancellationToken);
    }
}
