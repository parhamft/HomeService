﻿using HomeService.Domain.Core.HomeService.CustomerEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.Entities;
using HomeService.Domain.Core.HomeService.UserEntity.DTO;
using HomeService.Domain.Core.HomeService.UserEntity.Enums;
using HomeService.Domain.Core.HomeService.Users.Entities;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Security.Claims;


namespace App.Domain.AppService.HomeService.Account
{
    public class AccountAppService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountAppService(UserManager<User> UserManager, SignInManager<User> signInManager)
        {
            _userManager = UserManager;
            _signInManager = signInManager;
        }
        public async Task<IdentityResult> Register(CreateUserDTO createUserDTO,CancellationToken cancellationToken)
        {
            var User = new User();
            User.Email = createUserDTO.Email;
            User.UserName = createUserDTO.Email;
            User.FullName = $"{createUserDTO.FirstName} {createUserDTO.LastName}";
            var Role = "";
            if (createUserDTO.Role==RoleEnum.Expert)
            {
                Role = "Expert";
                User.Expert = new Expert
                {
                    FirstName= createUserDTO.FirstName,
                    LastName= createUserDTO.LastName,

                };
            }
            if (createUserDTO.Role == RoleEnum.Customer) 
            {
                Role = "Customer";
                User.Customer = new Customer
                {
                    FirstName = createUserDTO.FirstName,
                    LastName = createUserDTO.LastName,
                };

            }

            var result = await _userManager.CreateAsync(User, createUserDTO.Password);

            if (result.Succeeded) 
            {
                 await _userManager.AddToRoleAsync(User, Role);
                
                if (createUserDTO.Role == RoleEnum.Customer)
                {
                    await _userManager.AddClaimAsync(User, new Claim("CustomerId", User.Customer.Id.ToString()));
                }

                if (createUserDTO.Role == RoleEnum.Expert)
                {
                    await _userManager.AddClaimAsync(User, new Claim("ExopertId", User.Expert.Id.ToString()));
                }

               
            }


            return result;
        }
    }
}
