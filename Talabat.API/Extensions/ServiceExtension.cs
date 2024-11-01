using Core.Layer.RepositoriesInterface;
using Core.Layer.ServiceInterfaces;
using Repository.Layer.Repositories;
using Services.Layer;
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
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IOrderServices), typeof(OrderService));
            services.AddScoped(typeof(IAuthService),typeof(AuthService));   
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddSingleton(typeof(IResponseCachingService), typeof(ResponseCachingService));
            services.AddScoped(typeof(IPaymentService), typeof(PaymentService));   
            return services;
        }
    }
}
