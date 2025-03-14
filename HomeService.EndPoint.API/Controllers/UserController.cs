using App.Domain.AppService.HomeService.Account;
using HomeService.Domain.Core.HomeService.Account.AppService;
using HomeService.Domain.Core.HomeService.UserEntity.DTO;
using HomeService.Domain.Core.HomeService.Users.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAccountAppService _accountAppService;

        public UserController(IAccountAppService accountAppService)
        {
            _accountAppService = accountAppService;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDTO? createUserDTO, CancellationToken cancellationToken)
        {

            if (createUserDTO is null)
                return BadRequest(new { message = "داده‌های کاربر نمی‌توانند خالی باشند" });

            var result = await _accountAppService.Register(createUserDTO, cancellationToken);
            if (result.Succeeded)
            {

                return Ok(new { message = "کاربر با موفقیت اضافه شد", });
            }
            else
            {

                return BadRequest(new { message = "مشکلی به وجود اومد" });
            }



        }
    }
}
