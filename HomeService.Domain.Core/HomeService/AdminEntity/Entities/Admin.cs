using HomeService.Domain.Core.HomeService.Users.Entities;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.HomeService.AdminEntity.Entities
{
    public class Admin
    {
        #region Properties
        public int Id { get; set; }
        [MaxLength(100),MinLength(3)]
        public string? FirstName { get; set; }
        [MaxLength(100), MinLength(3)]
        public string? LastName { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeCreated { get; set; }
        #endregion

        #region NavigationProperties
        public User User { get; set; }
        #endregion



    }
}
