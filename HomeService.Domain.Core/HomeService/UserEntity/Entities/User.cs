using HomeService.Domain.Core.HomeService.AdminEntity.Entities;
using HomeService.Domain.Core.HomeService.CityEntity.Entities;
using HomeService.Domain.Core.HomeService.CustomerEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.HomeService.Users.Entities
{
    public class User : IdentityUser<int>
    {

        public string FullName { get; set; }

        #region NavigationProperties
        public Customer? Customer { get; set; }
        public Admin? Admin{ get; set; }
        public Expert? Expert { get; set; }
        #endregion

    }
}
