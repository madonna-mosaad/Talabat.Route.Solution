
using Microsoft.EntityFrameworkCore;
using Repository.Layer.Data.Context;
using Repository.Layer.Data;
using System;
using Talabat.API.MiddleWares;
using Talabat.API.Extensions;
using StackExchange.Redis;
using Core.Layer.RepositoriesInterface;
using Repository.Layer.Repositories;
using Repository.Layer.Data.Identity.Context;
using Microsoft.AspNetCore.Identity;
using Core.Layer.Models;


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
            builder.Services.AddDbContext<IdentityContext>(options => options
           .UseSqlServer(builder.Configuration.GetConnectionString("Identity")));
            builder.Services.AddIdentity<Users, IdentityRole>().AddEntityFrameworkStores<IdentityContext>();
            builder.Services.AddServices();
            builder.Services.AddValidErrorServices();
           // to register the MemoryDbContext(Redis Context)
            builder.Services.AddSingleton((provider) =>
            {
                var connect = builder.Configuration.GetConnectionString("Redis");
                return ConnectionMultiplexer.Connect(connect);
            });
            builder.Services.AddScoped<IBasketRepository, BasketRepository>();

            var app = builder.Build();
            //explicit dependency injection (must register any class inside GetRequiredService<>)
            using var scope = app.Services.CreateScope();
            var services= scope.ServiceProvider;
            var _dbContext= services.GetRequiredService<StoreDbContext>();
            var _identityContext = services.GetRequiredService<IdentityContext>();
            var _userManager = services.GetRequiredService < UserManager<Users>>();
            var loggerfactory= services.GetRequiredService<ILoggerFactory>();

            try
            {
                await _dbContext.Database.MigrateAsync();
                await _identityContext.Database.MigrateAsync();
                await StoreSeeding.SeedAsync(_dbContext);
                await IdentitySeeding.SeedAsync(_userManager);
            }
            catch (Exception ex) 
            {
                var logger = loggerfactory.CreateLogger<Program>();
                logger.LogError(ex, "a database error");
            }

            // Configure the HTTP request pipeline.

            //server error
            app.UseMiddleware<ExceptionMiddleWare>();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();
            //not found endpoint
            app.UseStatusCodePagesWithReExecute("/Errors/{0}");

            app.MapControllers();

            app.Run();
        }
    }
}
