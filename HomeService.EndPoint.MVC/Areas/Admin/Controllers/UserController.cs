using HomeService.Domain.Core.HomeService.Account.AppService;
using HomeService.Domain.Core.HomeService.BaseData.Service;
using HomeService.Domain.Core.HomeService.CityEntity.AppServices;
using HomeService.Domain.Core.HomeService.CustomerEntity.AppServices;
using HomeService.Domain.Core.HomeService.CustomerEntity.DTO;
using HomeService.Domain.Core.HomeService.CustomerEntity.Entities;
using HomeService.Domain.Core.HomeService.ExpertEntity.AppServices;
using HomeService.Domain.Core.HomeService.ExpertEntity.DTO;
using HomeService.Domain.Core.HomeService.UserEntity.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Areas.Admin.Controllers
{
    [Area(areaName: "Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly ICustomerAppService _customerAppService;
        private readonly IAccountAppService _accountAppService;
        private readonly IBaseDataService _baseDataService;
        private readonly ICityAppService _cityAppService;
        private readonly IExpertAppService _expertAppService;

        public UserController(ICustomerAppService customerAppService, IAccountAppService accountAppService,IBaseDataService baseDataService, ICityAppService cityAppService, IExpertAppService expertAppService)
        {
            _customerAppService = customerAppService;
            _accountAppService = accountAppService;
            _baseDataService = baseDataService;
            _cityAppService = cityAppService;
            _expertAppService = expertAppService;
        }
        public async Task<IActionResult> Customers(CancellationToken cancellationToken)
        {
            var result = await _customerAppService.GetAll(cancellationToken);
            return View(result);
        }
        public async Task<IActionResult> Experts(CancellationToken cancellationToken)
        {

            var result = await _expertAppService.GetAll(cancellationToken);
            return View(result);
        }
        public async Task<IActionResult> AddUser( CancellationToken cancellationToken)
        {

            var Cities = await _cityAppService.GetAll( cancellationToken);
            ViewBag.Cities = Cities;
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Adduser(CreateUserDTO createUserDTO, CancellationToken cancellationToken)
        {
            var result = await _accountAppService.Register(createUserDTO, cancellationToken);
            if (result.Succeeded)
            {
                return RedirectToAction("Customers");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    TempData["Message"] = error.Description;
                    TempData["AlertType"] = "danger";
                }
                return RedirectToAction("Adduser");
            }

        }
        public async Task<IActionResult> CustomerUpdate(int id, CancellationToken cancellationToken)
        {
            var result = await _customerAppService.GetUpdateDTO(id, cancellationToken);
            var Cities = await _cityAppService.GetAll(cancellationToken);
            ViewBag.Cities = Cities;
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Customerupdate(UpdateCustomerDTO updateCustomerDTO, CancellationToken cancellationToken)
        {
            await _customerAppService.Update(updateCustomerDTO, cancellationToken);
            return RedirectToAction("Customers");
        }
        public async Task<IActionResult> DeleteCustomer(int id, CancellationToken cancellationToken)
        {
            var result = await _customerAppService.Delete(id, cancellationToken);

            return RedirectToAction("Customers");
        }
        public async Task<IActionResult> ExpertUpdate(int id, CancellationToken cancellationToken)
        {
            var result = await _expertAppService.GetUpdate(id, cancellationToken);
            var Cities = await _cityAppService.GetAll(cancellationToken);
            ViewBag.Cities = Cities;
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Expertupdate(UpdateExpertDTO updateExpertDTO, CancellationToken cancellationToken)
        {
            if (updateExpertDTO.ProfileImgFile != null)
            {
                updateExpertDTO.ImagePath = await _baseDataService.UploadImage(updateExpertDTO.ProfileImgFile!, "Users", cancellationToken);
            }
            await _expertAppService.Update(updateExpertDTO, cancellationToken);
            return RedirectToAction("Customers");
        }
        public async Task<IActionResult> DeleteExpert(int id, CancellationToken cancellationToken)
        {
            var result = await _expertAppService.Delete(id, cancellationToken);

            return RedirectToAction("Experts");
        }

    }
}
