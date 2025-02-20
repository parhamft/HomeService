﻿using HomeService.Domain.Core.HomeService.CategoryEntity.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.SubCategoryEntity.DTO
{
    public class GetSubCategoryDTO
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string ImagePath { get; set; }
        public Category Category { get; set; }
    }
}
