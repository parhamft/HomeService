using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.OfferEntity.Entities;
using HomeService.Domain.Core.HomeService.OrderEntity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.OrderEntity.DTO
{
    public class OrderStatusUpdateDTO
    {
        public int Id { get; set; }
        public StatusEnum Status { get; set; }
        
        public List<Offer>? Offers { get; set; }
        public Expert? Expert { get; set; }
    }
}
