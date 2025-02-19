using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.OrderEntity.Entities;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.HomeServiceEntity.Entities
{
    public class Service
    {

        #region Properties
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int SubCategoryId { get; set; }
        public decimal BasePrice { get; set; }
        public string ImagePath { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeCreated { get; set; }
        #endregion

        #region NavigationProperties
        public SubCategory SubCategory { get; set; }
        public List<Expert>? Experts { get; set; }
        public List<Order>? Orders { get; set; }
        #endregion


    }
}
