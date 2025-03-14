using HomeService.Domain.Core.HomeService.Configs.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HomeService.EndPoint.API.Filters
{
    public class ApiFilter : ActionFilterAttribute
    {
        private readonly SiteSettings _siteSettings;

        public ApiFilter(SiteSettings siteSettings)
        {
            _siteSettings = siteSettings;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var apiKey = context.HttpContext.Request.Headers["apikey"].ToString();
            if (apiKey==null || apiKey != _siteSettings.ApiKey)
            {
                context.Result = new UnauthorizedObjectResult(new { message = "apikey  وارد شده اشتباه میباشد" });
            }
        }

    }
}
