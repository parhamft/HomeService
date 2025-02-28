namespace HomeService.Domain.Core.HomeService.CommentEntity.DTO
{
    public class UpdateStatusCommentDTO
    {
        public int Id { get; set; }
        public bool Approved { get; set; }
        public bool IsDeleted { get; set; }
    }
}