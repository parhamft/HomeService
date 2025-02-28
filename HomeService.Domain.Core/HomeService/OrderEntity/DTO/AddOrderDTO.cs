using HomeService.Domain.Core.HomeService.ImageEntity;
using HomeService.Domain.Core.HomeService.OrderEntity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.OrderEntity.DTO
{
    public class AddOrderDTO
    {
        public string Description { get; set; }
        public DateTime? DateFor { get; set; }
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
        public List<Image>?     Images { get; set; }
        public StatusEnum Status { get; set; }
        public int CityId { get; set; }
        public DateTime TimeCreated { get; set; } = DateTime.Now;

    }
}
