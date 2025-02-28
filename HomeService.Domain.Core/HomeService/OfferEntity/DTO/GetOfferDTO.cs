using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.OrderEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.OfferEntity.DTO
{
    public class GetOfferDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime? RequestTime { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
        public DateTime TimeCreated { get; set; }
        public Expert Expert { get; set; }
    }
}
