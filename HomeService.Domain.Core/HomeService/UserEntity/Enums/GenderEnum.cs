using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.UserEntity.Enums
{
    public enum GenderEnum
    {
        [Display(Name = "آقا")]
        Male = 1,

        [Display(Name = "خانم")]
        Female
    }
}
