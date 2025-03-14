using HomeService.Domain.Core.HomeService.CityEntity.AppServices;
using HomeService.Domain.Core.HomeService.ExpertEntity.AppServices;
using HomeService.Domain.Core.HomeService.ExpertEntity.DTO;
using HomeService.Domain.Core.HomeService.ServiceEntity.AppServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Areas.Expert.Controllers
{
    [Area(areaName:"Expert")]
    [Authorize(Roles = "Expert")]
    public class UpdateProfileController : Controller
    {
        private readonly IExpertAppService _expertAppService;
        private readonly IServiceAppService _serviceAppService;
        private readonly ICityAppService _cityAppService;

        public UpdateProfileController(IExpertAppService expertAppService, IServiceAppService serviceAppService, ICityAppService cityAppService)
        {
            _expertAppService = expertAppService;
            _serviceAppService = serviceAppService;
            _cityAppService = cityAppService;
        }
        public async Task<IActionResult> Index(int Id, CancellationToken cancellationToken)
        {
            var expert = await _expertAppService.GetById(Id, cancellationToken);
            ViewBag.Expert = expert;
            var services = await _serviceAppService.GetAll( cancellationToken);
            ViewBag.Services = services;
            var city = await _cityAppService.GetAll(cancellationToken);
            ViewBag.city = city;
            var Update = await _expertAppService.GetUpdate(Id, cancellationToken);

            return View(Update);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateExpertDTO updateExpertDTO, CancellationToken cancellationToken)
        {
            await _expertAppService.Update(updateExpertDTO, cancellationToken);
            return LocalRedirect($"/Expert/Dashboard/Index/{updateExpertDTO.Id}");
        }
    }
}
