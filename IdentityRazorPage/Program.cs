using IdentityRazorPage.Data;
using IdentityRazorPage.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityRazorPage
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                //To Register services used in RegisterPage
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            builder.Services.AddRazorPages();

            var app = builder.Build();
            using var scope = app.Services.CreateScope();
            var service= scope.ServiceProvider;
            var _dbContext= service.GetRequiredService<ApplicationDbContext>();
            var loggerfactory= service.GetRequiredService<ILoggerFactory>();

            try
            {
                await _dbContext.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                var logger = loggerfactory.CreateLogger<Program>();
                logger.LogError(ex, "a database error");
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
