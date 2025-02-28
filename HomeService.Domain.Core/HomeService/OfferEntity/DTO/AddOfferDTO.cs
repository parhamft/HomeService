using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.OfferEntity.DTO
{
    public class AddOfferDTO
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime? RequestTime { get; set; }
        public int OrderId { get; set; }
        public int ExpertId { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
