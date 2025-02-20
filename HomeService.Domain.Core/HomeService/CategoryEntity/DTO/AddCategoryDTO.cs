using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.CategoryEntity.DTO
{
    public class AddCategoryDTO
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public IFormFile? ProfileImgFile { get; set; }
        public string? ImagePath { get; set; }

        public DateTime TimeCreated { get; set; } = DateTime.Now;
    }
}
