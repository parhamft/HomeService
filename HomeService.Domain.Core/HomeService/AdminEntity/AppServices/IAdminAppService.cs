using HomeService.Domain.Core.HomeService.AdminEntity.Entities;
using HomeService.Domain.Core.HomeService.UserEntity.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeService.Domain.Core.HomeService.AdminEntity.AppServices
{
    public interface IAdminAppService
    {
        Task<IdentityResult> Register(CreateUserDTO createUserDTO, CancellationToken cancellationToken);
        Task<SignInResult> Login(string Email, string password, CancellationToken cancellationToken);
    }
}
