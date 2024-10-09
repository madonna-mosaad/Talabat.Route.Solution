using Core.Layer.RepositoriesInterface;
using Repository.Layer.Repositories;
using Talabat.API.Helpers;

namespace Talabat.API.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //builder.Services.AddScoped<IGenericRepository<Product>,GenericRepository<Product>>();
            //builder.Services.AddScoped<IGenericRepository<ProductBrand>, GenericRepository<ProductBrand>>();
            //builder.Services.AddScoped<IGenericRepository<ProductCategory>, GenericRepository<ProductCategory>>();
            //make this instead of register each module
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(MappingProfile));
            return services;
        }
    }
}
