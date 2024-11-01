using Core.Layer.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Talabat.API.Helpers
{
    public class Cached : Attribute, IAsyncActionFilter
    {
        private readonly int _expirTime;

        public Cached(int expirTime)
        {
            _expirTime = expirTime;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var CacheService= context.HttpContext.RequestServices.GetRequiredService<IResponseCachingService>();
            var key= GenerateCachKeyFromRequestParameters(context.HttpContext.Request);
            var CacheResponse=await CacheService.GetCacheResponseAsync(key);
            if (!string.IsNullOrEmpty(CacheResponse))
            {
                context.Result = new ContentResult()
                {
                    Content = CacheResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };
                return;
            }
            var EndpointExcute =await next.Invoke();
            if(EndpointExcute.Result is OkObjectResult result)
            {
                await CacheService.CacheResponseAsync(key, result.Value, TimeSpan.FromSeconds(_expirTime));
            }


        }

        private string GenerateCachKeyFromRequestParameters(HttpRequest request)
        {
            var keyBuilder = new StringBuilder();
            keyBuilder.Append(request.Path);// api/{Controller}
            foreach (var (key, value) in request.Query.OrderBy(x => x.Key))
            {
                keyBuilder.Append($"|{key}-{value}");
            }
            return keyBuilder.ToString();
        }
    }
}
