using HomeService.Domain.Core.HomeService.CustomerEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.HomeServiceEntity.Entities;
using HomeService.Domain.Core.HomeService.ImageEntity;
using HomeService.Domain.Core.HomeService.OfferEntity.Entities;
using HomeService.Domain.Core.HomeService.OrderEntity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.OrderEntity.DTO
{
    public class GetOrderDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? DateFor { get; set; }
        public Customer Customer { get; set; }
        public Service Service { get; set; }
        public Expert? Expert { get; set; }
        public List<Offer>? Offers { get; set; }
        public StatusEnum Status { get; set; }
        public List<Image>? Images { get; set; }
    }
}
