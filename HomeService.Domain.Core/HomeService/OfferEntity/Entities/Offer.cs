using HomeService.Domain.Core.HomeService.CommentEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.OrderEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.OfferEntity.Entities
{
    public class Offer
    {
        #region Property
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime? RequestTime { get; set; }
        public int OrderId { get; set; }
        public int ExpertId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeCreated { get; set; }
        #endregion
        #region NavifationProperty
        public Order Order { get; set; }

        public Expert Expert { get; set; }

        #endregion
    }
}
