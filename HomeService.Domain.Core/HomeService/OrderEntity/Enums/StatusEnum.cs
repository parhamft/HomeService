using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.OrderEntity.Enums
{
    public enum StatusEnum
    {
        WaitingForExperts = 1,
        WaitingToBeAccepted,
        ExpertAccepted,
        WaitingForPayment,
        Done
    }
}
