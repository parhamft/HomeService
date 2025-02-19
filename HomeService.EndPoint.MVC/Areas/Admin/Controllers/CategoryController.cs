using HomeService.Domain.Core.HomeService.CategoryEntity.AppServices;
using HomeService.Domain.Core.HomeService.CategoryEntity.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.MVC.Areas.Admin.Controllers
{
    [Area(areaName: "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService)
        {
            _categoryAppService = categoryAppService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
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
    }
}
