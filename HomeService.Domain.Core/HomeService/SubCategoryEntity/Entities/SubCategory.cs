using HomeService.Domain.Core.HomeService.CategoryEntity.Entities;
using HomeService.Domain.Core.HomeService.HomeServiceEntity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.SubCategoryEntity.Entities
{
    public class SubCategory
    {
        #region Properties
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
        #endregion

        #region NavigationProperties
        public Category Category { get; set; }
        public List<Service>? Services { get; set; }
        #endregion
    }
}
