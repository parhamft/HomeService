using HomeService.Domain.Core.HomeService.BaseData.Service;
using HomeService.Domain.Core.HomeService.CategoryEntity.AppServices;
using HomeService.Domain.Core.HomeService.CategoryEntity.DTO;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.AppServices;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Areas.Admin.Controllers
{
    [Area(areaName: "Admin")]
    [Authorize(Roles = "Admin")]
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryAppService _subCategoryAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly IBaseDataService _baseDataService;

        public SubCategoryController(ISubCategoryAppService subCategoryAppService,ICategoryAppService categoryAppService, IBaseDataService baseDataService)
        {
            _subCategoryAppService = subCategoryAppService;
            _categoryAppService = categoryAppService;
            _baseDataService = baseDataService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var result = await _subCategoryAppService.GetAll(cancellationToken);

            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            var categories = await _categoryAppService.GetAll(cancellationToken);
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddSubCategoryDTO addSubCategoryDTO, CancellationToken cancellationToken)
        {
            var result = await _subCategoryAppService.Add(addSubCategoryDTO, cancellationToken);
            if (result == false)
            {
                throw new Exception("مشکلی به وجود آمد");
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdatePage(int Id, CancellationToken cancellationToken)
        {
            var result = await _subCategoryAppService.GetUpdate(Id, cancellationToken);
            var categories = await _categoryAppService.GetAll(cancellationToken);
            ViewBag.Categories = categories;
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSubCategoryDTO updateSubCategoryDTO, CancellationToken cancellationToken)
        {
            updateSubCategoryDTO.ImagePath = await _baseDataService.UploadImage(updateSubCategoryDTO.ProfileImgFile!, "SubCategory", cancellationToken);
            var result = await _subCategoryAppService.Update(updateSubCategoryDTO, cancellationToken);
            if (result == false)
            {
                throw new Exception("مشکلی به وجود آمد");
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int Id, CancellationToken cancellationToken)
        {
            var result = await _subCategoryAppService.Delete(Id, cancellationToken);


            return RedirectToAction("Index");
        }
    }
}
