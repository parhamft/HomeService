using HomeService.Domain.Core.HomeService.CommentEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.CommentEntity.Data
{
    public interface ICommentRepository
    {
         Task<List<Comment>> GetAll(CancellationToken cancellationToken);
         Task<Comment> GetById(int Id, CancellationToken cancellationToken);
         Task<bool> Create(Comment comment, CancellationToken cancellationToken);
         Task<bool> Update(Comment comment, CancellationToken cancellationToken);
         Task<bool> Delete(int Id, CancellationToken cancellationToken);
    }
}
