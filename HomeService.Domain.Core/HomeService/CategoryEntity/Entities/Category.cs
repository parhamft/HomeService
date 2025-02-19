using HomeService.Domain.Core.HomeService.HomeServiceEntity.Entities;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.Entities;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.HomeService.CategoryEntity.Entities
{
    public class Category
    {
        #region Properties
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeCreated { get; set; }

        #endregion

        #region NavigationProperties
        public List<SubCategory>? SubCategories { get; set; }
        #endregion
    }
}
