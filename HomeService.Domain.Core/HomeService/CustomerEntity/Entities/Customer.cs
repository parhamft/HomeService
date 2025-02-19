using HomeService.Domain.Core.HomeService.CommentEntity.Entities;
using HomeService.Domain.Core.HomeService.OrderEntity.Entities;
using HomeService.Domain.Core.HomeService.UserEntity.Enums;
using HomeService.Domain.Core.HomeService.Users.Entities;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.HomeService.CustomerEntity.Entities
{
    public class Customer
    {
        #region Properties
       public int Id { get; set; }
        [MaxLength(100), MinLength(3)]
        public string? FirstName { get; set; }
        [MaxLength(100), MinLength(3)]
        public string? LastName { get; set; }
        public GenderEnum? Gender { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }
        public string?  ImagePath{ get; set; }
        public bool IsDeleted { get; set; }
        public DateTime TimeCreated { get; set; }
        #endregion

        #region NavigationProperties
        public List<Comment>? Comments { get; set; }
        public List<Order>? Orders { get; set; }
        public User User { get; set; }

        #endregion

    }
}
