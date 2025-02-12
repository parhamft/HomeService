using HomeService.Domain.Core.HomeService.CustomerEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.OfferEntity.Entities;
using HomeService.Domain.Core.HomeService.OrderEntity.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeService.Domain.Core.HomeService.CommentEntity.Entities
{
    public class Comment
    {
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Score { get; set; }
        public int CustomerId { get; set; }


        public int OfferId { get; set; }
        public bool Approved { get; set; }
        public int ExpertId { get; set; }
        #endregion
        #region NavigationProperties
        public Customer Customer { get; set; }
        public Expert Expert { get; set; }
        public Offer Offer { get; set; }
        #endregion

    }
}
