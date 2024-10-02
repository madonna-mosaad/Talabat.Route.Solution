using Talabat.API.Helpers;
using Core.Layer.Models;
using Core.Layer.RepositoriesInterface;
using Microsoft.EntityFrameworkCore;
using Repository.Layer.Data.Context;
using Repository.Layer.Data;
using Repository.Layer.Repositories;
using System;

namespace Talabat.API
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<StoreDbContext>(options => options
            .UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            //builder.Services.AddScoped<IGenericRepository<Product>,GenericRepository<Product>>();
            //builder.Services.AddScoped<IGenericRepository<ProductBrand>, GenericRepository<ProductBrand>>();
            //builder.Services.AddScoped<IGenericRepository<ProductCategory>, GenericRepository<ProductCategory>>();
            //make this instead of register each module
            builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var app = builder.Build();
            //explicit dependency injection
            using var scope = app.Services.CreateScope();
            var services= scope.ServiceProvider;
            var _dbContext= services.GetRequiredService<StoreDbContext>();
            var loggerfactory= services.GetRequiredService<ILoggerFactory>();

            try
            {
                await _dbContext.Database.MigrateAsync();
                await StoreSeeding.SeedAsync(_dbContext);
            }
            catch (Exception ex) 
            {
                var logger = loggerfactory.CreateLogger<Program>();
                logger.LogError(ex, "a database error");
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
