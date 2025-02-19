using HomeService.Domain.Core.HomeService.SubCategoryEntity.DTO;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.CategoryEntity.DTO
{
    public class GetCategoryWithSubCategoryDTO
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public List<GetSubCategoryWithServiceDTO>? SubCategories { get; set; }
    }
}
