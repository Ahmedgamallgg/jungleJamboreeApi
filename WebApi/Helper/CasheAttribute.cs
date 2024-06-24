using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Services.CasheService.Interface;
using System.Text;

namespace WebApi.Helper
{
    public class CasheAttribute : Attribute, IAsyncActionFilter
    {
        private readonly int _TimeToLiveInSec;

        public CasheAttribute(int timeToLiveInSec)
        {
            _TimeToLiveInSec = timeToLiveInSec;
        }

        

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var casheService = context.HttpContext.RequestServices.GetRequiredService<ICasheService>();

            var casheKey = GenerateCasheKeyFromReqyest(context.HttpContext.Request);

            var casheResponse = await casheService.GetCasheResponseAsync(casheKey);

            if (!string.IsNullOrEmpty(casheResponse))
            {
                var contentResult = new ContentResult
                {
                    Content = casheResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };
                context.Result = contentResult;
                return;
            }

            var executeContext = await next();

            if (executeContext.Result is OkObjectResult okObjectResult)
                await casheService.SetCasheResponseAsync(casheKey, okObjectResult.Value, TimeSpan.FromSeconds(_TimeToLiveInSec));
        }

        private string GenerateCasheKeyFromReqyest(HttpRequest request)
        {
            var cashekey = new StringBuilder();

            cashekey.Append($"{request.Path}");

            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
                cashekey.Append($"|{key}-{value}");

            return cashekey.ToString();
        }
    }
}
