﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.ServiceEntity.DTO
{
    public class AddServiceDTO
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public int SubCategoryId { get; set; }
        public decimal BasePrice { get; set; }
        public IFormFile? ProfileImgFile { get; set; }
        public string ImagePath { get; set; }
        public DateTime TimeCreated { get; set; }
    }
}
