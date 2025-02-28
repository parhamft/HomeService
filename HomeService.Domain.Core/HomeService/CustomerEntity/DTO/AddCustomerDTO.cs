using HomeService.Domain.Core.HomeService.CityEntity.Entities;
using HomeService.Domain.Core.HomeService.UserEntity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.CustomerEntity.DTO
{
    public class AddCustomerDTO
    {
        public string Email { get; set; }
        public string Password{ get; set; }
        public RoleEnum Role { get; set; }
        public int CityId { get; set; }
    }
}
