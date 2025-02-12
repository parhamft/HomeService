using HomeService.Domain.Core.HomeService.CommentEntity.Entities;
using HomeService.Domain.Core.HomeService.CustomerEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.HomeServiceEntity.Entities;
using HomeService.Domain.Core.HomeService.OfferEntity.Entities;
using HomeService.Domain.Core.HomeService.OrderEntity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.OrderEntity.Entities
{
    public class Order
    {
        #region Properties
       public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateFor { get; set; }
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
        public StatusEnum Status { get; set; }
        public int? ExpertId { get; set; }
        #endregion

        #region NavigationProperties
        public Customer Customer { get; set; }
        public Service Service { get; set; }

        public Expert? Expert { get; set; }

        public List<Offer>? Offers { get; set; }

        #endregion
 

    }
}
