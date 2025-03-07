using HomeService.Domain.Core.HomeService.Users.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.AdminEntity.DTO
{
    public class UpdateAdminDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        [MaxLength(100), MinLength(3)]
        public string? LastName { get; set; }
        public decimal Balance { get; set; }
        public User User { get; set; }
    }
}
