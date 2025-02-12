using HomeService.Domain.Core.HomeService.Users.Entities;

namespace HomeService.Domain.Core.HomeService.AdminEntity.Entities
{
    public class Admin
    {
        #region Properties
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal Balance { get; set; }

        #endregion

        #region NavigationProperties
        public User User { get; set; }
        #endregion



    }
}
