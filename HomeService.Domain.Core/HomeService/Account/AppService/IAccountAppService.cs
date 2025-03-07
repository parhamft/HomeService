using HomeService.Domain.Core.HomeService.CustomerEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.UserEntity.DTO;
using HomeService.Domain.Core.HomeService.UserEntity.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.Account.AppService
{
    public interface IAccountAppService
    {
        Task<IdentityResult> Register(CreateUserDTO createUserDTO, CancellationToken cancellationToken);
         Task<SignInResult> Login(string Email, string password, CancellationToken cancellationToken);
         Task Logout(CancellationToken cancellationToken);
    }
}
