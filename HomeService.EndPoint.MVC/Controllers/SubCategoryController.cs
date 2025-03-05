using HomeService.Domain.Core.HomeService.SubCategoryEntity.AppServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace HomeService.EndPoint.MVC.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly ISubCategoryAppService _subCategoryAppService;

        public SubCategoryController(ISubCategoryAppService subCategoryAppService)
        {
            _subCategoryAppService = subCategoryAppService;
        }
        public async Task<IActionResult> Index(int Id,CancellationToken cancellationToken)
        {
            var SubCategories = await _subCategoryAppService.GetAllOfCategory(Id,cancellationToken);
            ViewBag.SubCategories = SubCategories;
            return View();
        }
    }
}
