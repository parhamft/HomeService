using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.ServiceEntity.DTO
{
    public class UpdateServiceDTO
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public int SubCategoryId { get; set; }
        public string ImagePath { get; set; }
    }
}
