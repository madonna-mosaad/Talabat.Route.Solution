using System.Text.Json;
using Talabat.API.Response;

namespace Talabat.API.MiddleWares
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleWare> _logger;
        private readonly IWebHostEnvironment _environment;

        public ExceptionMiddleWare(RequestDelegate next ,ILogger<ExceptionMiddleWare> logger,IWebHostEnvironment environment)
        {
            _next = next;
            _logger = logger;
            _environment = environment;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next.Invoke(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,ex.Message);

                httpContext.Response.ContentType = "aplication/json";
                httpContext.Response.StatusCode = 500;

                var response = _environment.IsDevelopment() ? new ApiExceptionResponse(500,ex.Message,ex.StackTrace.ToString()) : new ApiExceptionResponse(500);
                var options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                var json = JsonSerializer.Serialize(response);

                await httpContext.Response.WriteAsync(json);
            }
        }
    }
}
