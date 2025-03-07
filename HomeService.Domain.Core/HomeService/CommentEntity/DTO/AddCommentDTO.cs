using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.CommentEntity.DTO
{
    public class AddCommentDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Score { get; set; }
        public int CustomerId { get; set; }
        public int OfferId { get; set; }

        public int ExpertId { get; set; }
    }
}
