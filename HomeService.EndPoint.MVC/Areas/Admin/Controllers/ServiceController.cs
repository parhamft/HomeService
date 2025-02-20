using HomeService.Domain.Core.HomeService.CategoryEntity.AppServices;
using HomeService.Domain.Core.HomeService.ServiceEntity.AppServices;
using HomeService.Domain.Core.HomeService.ServiceEntity.DTO;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.AppServices;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Areas.Admin.Controllers
{
    [Area(areaName: "Admin")]
    public class ServiceController : Controller
    {
        private readonly ISubCategoryAppService _subCategoryAppService;
        private readonly IServiceAppService _serviceAppService;

        public ServiceController(ISubCategoryAppService subCategoryAppService, IServiceAppService serviceAppService)
        {
            _subCategoryAppService = subCategoryAppService;
            _serviceAppService = serviceAppService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            
            var result = await _serviceAppService.GetAll(cancellationToken);

            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            var categories = await _subCategoryAppService.GetAll(cancellationToken);
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddServiceDTO addServiceDTO, CancellationToken cancellationToken)
        {
            var result = await _serviceAppService.Add(addServiceDTO, cancellationToken);
            if (result == false)
            {
                throw new Exception("مشکلی به وجود آمد");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdatePage(int Id, CancellationToken cancellationToken)
        {
            var result = await _serviceAppService.GetUpdate(Id, cancellationToken);
            var categories = await _subCategoryAppService.GetAll(cancellationToken);
            ViewBag.Categories = categories;
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateServiceDTO updateServiceDTO, CancellationToken cancellationToken)
        {
            var result = await _serviceAppService.Update(updateServiceDTO, cancellationToken);
            if (result == false)
            {
                throw new Exception("مشکلی به وجود آمد");
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _serviceAppService.Delete(Id, cancellationToken);


            return RedirectToAction("Index");
        }
    }
}
