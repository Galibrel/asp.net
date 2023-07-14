using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebmvc.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SalesWebmvc.Data;
using SalesWebmvc.Services;

namespace SalesWebmvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<SalesWebmvcContext>(options =>
                options.UseMySql(builder.Configuration.GetConnectionString("SalesWebmvcContext"), new MySqlServerVersion("8.0.23")));//comando para executar o migration, e criar as tabelas apartir das classes.

            builder.Services.AddScoped<SeedingService>();//instanciando o serviço na injeção
            builder.Services.AddScoped<SellerService>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();



            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var serviceProvider = app.Services;
            using (var scope = serviceProvider.CreateScope())
            {
                var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
                seedingService.Seed(); // Chame o método responsável pela população dos dados
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}