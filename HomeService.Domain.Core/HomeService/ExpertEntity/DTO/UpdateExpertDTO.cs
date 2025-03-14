using HomeService.Domain.Core.HomeService.CityEntity.Entities;
using HomeService.Domain.Core.HomeService.HomeServiceEntity.Entities;
using HomeService.Domain.Core.HomeService.UserEntity.Enums;
using HomeService.Domain.Core.HomeService.Users.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.ExpertEntity.DTO
{
    public class UpdateExpertDTO
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [MaxLength(50)]
        public string? LastName { get; set; }
        public GenderEnum? Gender { get; set; }
        public decimal Balance { get; set; }
        public decimal? Rating { get; set; }
        public string? ImagePath { get; set; }
        public int? CityId { get; set; }
        public City? City { get; set; }
        public User User { get; set; }
        public List<int>? servicesId { get; set; } = new List<int>();
        public List<Service>? services { get; set; } = new List<Service>();
        public IFormFile? ProfileImgFile { get; set; }
    }
}
