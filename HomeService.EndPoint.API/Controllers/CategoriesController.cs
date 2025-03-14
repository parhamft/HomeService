using HomeService.Domain.Core.HomeService.CategoryEntity.AppServices;
using HomeService.Domain.Core.HomeService.ServiceEntity.AppServices;
using HomeService.Domain.Core.HomeService.SubCategoryEntity.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace HomeService.EndPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;
        private readonly ISubCategoryAppService _subCategoryAppService;
        private readonly IServiceAppService _serviceAppService;

        public CategoriesController(ICategoryAppService categoryAppService, ISubCategoryAppService subCategoryAppService, IServiceAppService serviceAppService)
        {
            _categoryAppService = categoryAppService;
            _subCategoryAppService = subCategoryAppService;
            _serviceAppService = serviceAppService;
        }
        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories( CancellationToken cancellationToken)
        {
            var categories = await _categoryAppService.GetAll(cancellationToken);
            return Ok(categories);
        }
        [HttpGet("GetSubCategories")]
        public async Task<IActionResult> GetSubCategories([FromHeader] string? apikey, CancellationToken cancellationToken)
        {
            var subCategories = await _subCategoryAppService.GetAll(cancellationToken);
            return Ok(subCategories);
        }

        [HttpGet("GetServices")]
        public async Task<IActionResult> GetHomeServices([FromHeader] string? apikey, CancellationToken cancellationToken)
        {
            var homeServices = await _serviceAppService.GetAll(cancellationToken);
            return Ok(homeServices);
        }
    }
}
