using HomeService.Domain.Core.HomeService.CommentEntity.AppServices;
using HomeService.Domain.Core.HomeService.CommentEntity.DTO;
using HomeService.Domain.Core.HomeService.CommentEntity.Entities;
using HomeService.Domain.Core.HomeService.CommentEntity.Services;
using HomeService.Domain.Core.HomeService.ExpertEntity.AppServices;

namespace App.Domain.AppService.HomeService.CommentEntity
{
    public class CommentAppService : IcommentAppService
    {
        private readonly ICommentService _commentService;
        private readonly IExpertAppService _expertAppService;

        public CommentAppService(ICommentService commentService, IExpertAppService expertAppService)
        {
            _commentService = commentService;
            _expertAppService = expertAppService;
        }
        public async Task<List<GetCommentDTO>> GetPendings(CancellationToken cancellationToken)
        {
            return await _commentService.GetPendings(cancellationToken);
        }
        public async Task<List<GetCommentDTO>> GetUsersComments(int Id, CancellationToken cancellationToken)
        {
            return await _commentService.GetUsersComments(Id, cancellationToken);
        }
        public async Task<List<GetCommentDTO>> GetExpertsComments(int Id, CancellationToken cancellationToken)
        {
            return await _commentService.GetExpertsComments(Id, cancellationToken);
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
        public async Task<bool> Create(AddCommentDTO comment, CancellationToken cancellationToken)
        {
            return await _commentService.Create(comment, cancellationToken);
        }
        public async Task<bool> Update(Comment comment, CancellationToken cancellationToken)
        {
            return await _commentService.Update(comment, cancellationToken);
        }
        public async Task<bool> ChangeStatus(int commentId, int actionId, int ExpertId, CancellationToken cancellationToken)
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
            await _commentService.ChangeStatus(comment, cancellationToken);

            var Comments = await _commentService.GetExpertsComments(ExpertId, cancellationToken);
            decimal sum = 0;
            var Expert = await _expertAppService.GetUpdate(ExpertId, cancellationToken);
            if (Comments.Count() != 0)
            {
                foreach (var i in Comments)
                {
                    sum += i.Score;
                }

                Expert.Rating = sum / Comments.Count();
            }
            else
            {
                Expert.Rating = 1;
            }
            return await _expertAppService.Update(Expert, cancellationToken);

        }
        public async Task<bool> Delete(int Id, CancellationToken cancellationToken)
        {
            return await _commentService.Delete(Id, cancellationToken);
        }
    }
}
