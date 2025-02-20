using HomeService.Domain.Core.HomeService.CategoryEntity.AppServices;
using HomeService.Domain.Core.HomeService.CategoryEntity.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Areas.Admin.Controllers
{
    [Area(areaName: "Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        public async Task<IActionResult> Index( CancellationToken cancellationToken)
        {
            var result = await _categoryAppService.GetAll(cancellationToken);

            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(AddCategoryDTO categoryDTO, CancellationToken cancellationToken)
        {
            var result = await _categoryAppService.Add(categoryDTO, cancellationToken);
            if (result == false)
            {
                throw new Exception("مشکلی به وجود آمد");
            }
            return View();
        }

        public async Task<IActionResult> UpdatePage(int Id , CancellationToken cancellationToken)
        {
            var result = await _categoryAppService.GetUpdate(Id, cancellationToken);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryDTO categoryDTO, CancellationToken cancellationToken)
        {
            var result = await _categoryAppService.Update(categoryDTO, cancellationToken);
            if (result == false)
            {
                throw new Exception("مشکلی به وجود آمد");
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int Id,CancellationToken cancellationToken)
        {
            var result = await _categoryAppService.Delete(Id, cancellationToken);


            return RedirectToAction("Index");
        }
    }
}
