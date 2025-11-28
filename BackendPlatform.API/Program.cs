using BackendPlatform.API.Core;
using BackendPlatform.API.Extensions;
using BackendPlatform.Core.Helpers;
using BackendPlatform.Core.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BackendPlatform.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.InitAppSettings();
            builder.Services.AddScoped<HttpHelper>();

            builder.Services.AddApplicationParts();

            builder.Services.AddControllers();
            builder.Services.AddSingleton<AppControllerTransformer>();

            //builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddScopedServices();
            builder.Services.AddAllServices();
            builder.Services.AddHttpClients();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            //app.UseRouting();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller}/{action}");

            app.MapDynamicControllerRoute<AppControllerTransformer>("{area}/{controller}/{action}");

            //app.MapControllers();

            app.Run();
        }
    }
}
