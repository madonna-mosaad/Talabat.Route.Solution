using Core.Layer.RepositoriesInterface;
using Microsoft.AspNetCore.Mvc;
using Repository.Layer.Repositories;
using Talabat.API.Helpers;
using Talabat.API.Response;

namespace Talabat.API.Extensions
{
    public static class ValidationErrorExtension
    {
        public static IServiceCollection AddValidErrorServices(this IServiceCollection services)
        {

            //validation error response
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (action) =>
                {
                    var errors = action.ModelState.Where(p => p.Value.Errors.Count() > 0).SelectMany(p => p.Value.Errors).Select(e => e.ErrorMessage).ToList();

                    var response = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(response);
                };
            });
            return services;
        }
    }
}
