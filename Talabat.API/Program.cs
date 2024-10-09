
using Microsoft.EntityFrameworkCore;
using Repository.Layer.Data.Context;
using Repository.Layer.Data;
using System;
using Talabat.API.MiddleWares;
using Talabat.API.Extensions;


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
            builder.Services.AddServices();
            builder.Services.AddValidErrorServices();

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
