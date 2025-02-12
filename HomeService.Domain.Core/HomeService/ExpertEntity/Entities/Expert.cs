using HomeService.Domain.Core.HomeService.CityEntity.Entities;
using HomeService.Domain.Core.HomeService.CommentEntity.Entities;
using HomeService.Domain.Core.HomeService.HomeServiceEntity.Entities;
using HomeService.Domain.Core.HomeService.OfferEntity.Entities;
using HomeService.Domain.Core.HomeService.OrderEntity.Entities;
using HomeService.Domain.Core.HomeService.UserEntity.Enums;
using HomeService.Domain.Core.HomeService.Users.Entities;
using System.ComponentModel.DataAnnotations;

namespace HomeService.Domain.Core.HomeService.ExpertEntity.Entities
{
    public class Expert
    {
        #region Properties
        public int Id { get; set; }
        [MaxLength(50)]
        public string? FirstName { get; set; }
        [MaxLength(50)]
        public string? LastName { get; set; }
        public GenderEnum? Gender { get; set; }
        public decimal Balance { get; set; }
        public int UserId { get; set; }
        public decimal? Rating { get; set; }
        public string? ImagePath { get; set; }
        #endregion

        #region NavigationProperties
        public List<Service>? Services { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Offer>? offers { get; set; }
        public List<Order>? AcceptedOffers { get; set; }
        public City? City { get; set; }
        public User User { get; set; }
        #endregion


    }
}
