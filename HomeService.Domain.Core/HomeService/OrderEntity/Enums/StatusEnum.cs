using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.OrderEntity.Enums
{
    public enum StatusEnum
    {
        [Display(Name = "در انتظار متخصص")]
        WaitingForExperts = 1,
        [Display(Name = "در انتظار قبول کردن مشتری")]
        WaitingToBeAccepted,
        [Display(Name = "متخصص انتخاب شد")]
        ExpertAccepted,
        [Display(Name = "در انتظار پرداخت")]
        WaitingForPayment,
        [Display(Name = "اتمام یافته")]
        Done
    }
}
