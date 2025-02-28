using HomeService.Domain.Core.HomeService.CustomerEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.OfferEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.CommentEntity.DTO
{
    public class GetCommentDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Score { get; set; }
        public bool Approved { get; set; }
        public DateTime TimeCreated { get; set; }
        public Customer Customer { get; set; }
        public Expert Expert { get; set; }
        public Offer Offer { get; set; }
        public bool IsDeleted { get; set; }
    }
}
