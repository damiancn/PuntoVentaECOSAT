using AutoMapper;
using ContextoDBPVECOSAT.Data;
using Microsoft.EntityFrameworkCore;

namespace PuntoVentaECOSAT
{
    public static class Startup
    {
        public static WebApplication InicializarApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfServicios(builder);
            var app = builder.Build();
            Conf(app);
            return app;

        }

        private static void ConfServicios(WebApplicationBuilder builder)
        {

            // Add services to the container.

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<Contexto>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddScoped(prov => new MapperConfiguration
            (cfg => {
                cfg.AddProfile(new AutoMapperClass());
            }).CreateMapper());
        }
        public static void Conf(WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller}/{action=Index}/{id?}");

            app.MapFallbackToFile("index.html"); ;
        }
    }
}
