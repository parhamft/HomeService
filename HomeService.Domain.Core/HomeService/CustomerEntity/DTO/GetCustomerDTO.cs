using HomeService.Domain.Core.HomeService.UserEntity.Enums;
using HomeService.Domain.Core.HomeService.Users.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.CustomerEntity.DTO
{
    public class GetCustomerDTO
    {
        public int Id { get; set; }
        [MaxLength(100), MinLength(3)]
        public string? FirstName { get; set; }
        [MaxLength(100), MinLength(3)]
        public string? LastName { get; set; }
        public GenderEnum? Gender { get; set; }
        public decimal Balance { get; set; }
        public string? ImagePath { get; set; }
        public DateTime TimeCreated { get; set; }
        public User User { get; set; }
    }
}
