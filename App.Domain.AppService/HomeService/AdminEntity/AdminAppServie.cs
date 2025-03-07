using HomeService.Domain.Core.HomeService.AdminEntity.AppServices;
using HomeService.Domain.Core.HomeService.AdminEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.UserEntity.DTO;
using HomeService.Domain.Core.HomeService.Users.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.AppService.HomeService.AdminEntity
{
    public class AdminAppServie : IAdminAppService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AdminAppServie(UserManager<User> UserManager, SignInManager<User> signInManager)
        {
            _userManager = UserManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> Register(CreateUserDTO createUserDTO, CancellationToken cancellationToken)
        {
            var User = new User();
            User.Email = createUserDTO.Email;
            User.UserName = createUserDTO.Email;
            User.FullName = $"{createUserDTO.FirstName} {createUserDTO.LastName}";
            var Role = "Admin";
            User.Admin = new Admin
            {
                FirstName = createUserDTO.FirstName,
                LastName = createUserDTO.LastName,

            };
            var result = await _userManager.CreateAsync(User, createUserDTO.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(User, Role);
            }


            return result;

        }
        public async Task<SignInResult> Login(string Email, string password,CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(Email,password, true,false);
            return result;
        }
        
    }
}
