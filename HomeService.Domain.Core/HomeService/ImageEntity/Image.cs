using HomeService.Domain.Core.HomeService.OrderEntity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.ImageEntity
{
    public class Image
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
