using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using BackendPlatform.Core.Models;
using BackendPlatform.Service.Models;
using static Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;
using BackendPlatform.Core.ConstData;

namespace BackendPlatform.API.Extensions
{
    public static class ServiceExtensions
    {
        private static readonly string _dirPath;

        // 下面這個資料應該從資料庫而來
        private static string[] platforms = new string[] { "LuckyStar", "FullRich" };

        static ServiceExtensions()
        {
            _dirPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>
        /// 載入每個平台的JSON設定檔
        /// </summary>
        /// <param name="builder"></param>
        public static void InitAppSettings(this WebApplicationBuilder builder)
        {
            var envName = builder.Environment.EnvironmentName;

            foreach (var p in platforms)
            {
                builder.Configuration
                .AddJsonFile($"appsettings.{p}.{envName}.json", true, true)
                .AddJsonFile($"appsettings.{p}.{envName}.DB.json", true, true)
                .AddJsonFile($"appsettings.{p}.{envName}.LOG.json", true, true); ;
            }

            builder.Configuration.AddEnvironmentVariables();

            AppSettings.Environment.EnvironmentName = envName;
            AppSettings.Configuration = builder.Configuration;
        }

        public static IServiceCollection AddScopedServices(this IServiceCollection services)
        {
            // 加入每個平台的物件
            var serviceNamespaces = new List<string>(platforms.Length * 2);
            var assemblies = new List<Assembly>(platforms.Length);

            foreach (var p in platforms)
            {
                assemblies.Add(Assembly.LoadFrom(Path.Combine(_dirPath, $"BackendPlatform.Service.{p}.dll")));
                serviceNamespaces.Add($"BackendPlatform.Service.{p}.Service.Services");
                serviceNamespaces.Add($"BackendPlatform.Service.{p}.Repository.Services");
            }
            
            return services.Scan(scan => scan
               .FromAssemblies(assemblies)
               .AddClasses(x => x.InNamespaces(serviceNamespaces))
               .AsImplementedInterfaces()
               .WithScopedLifetime()
           );
        }

        public static IServiceCollection AddAllServices(this IServiceCollection services)
        {
            // 1. 加入每個平台的物件
            var serviceNamespaces = new List<string>(platforms.Length + 1);
            var assemblies = new List<Assembly>(platforms.Length + 1);

            foreach(var p in platforms)
            {
                assemblies.Add(Assembly.LoadFrom(Path.Combine(_dirPath, $"BackendPlatform.Service.{p}.dll")));
                serviceNamespaces.Add($"BackendPlatform.Service.{p}.Service.Services");
            }

            // 2. 加入基底的物件
            assemblies.Add(Assembly.LoadFrom(Path.Combine(_dirPath, "BackendPlatform.Service.dll")));
            serviceNamespaces.Add($"BackendPlatform.Service.Service.Services");
            serviceNamespaces.Add($"BackendPlatform.Service.Core.API.Services");

            return services.Scan(scan => scan
                .FromAssemblies(assemblies)
                .AddClasses(s => s.InNamespaces(serviceNamespaces))
                .AsMatchingInterface()
                .WithScopedLifetime()
            );
        }

        /// <summary>
        /// 動態載入每個平台系統的 Controller, Service, 併入到當前的應用程式
        /// 
        /// 說明: 由於 BackendPlatform.API 並不會也不應該去參考每個平台的 dll,
        /// 而且每個平台 (例如 BackendPlatform.API.FullRich) 本身就會把 BackendPlatform.API 加入參考,
        /// 所以如果 BackendPlatform.API 再去參考每個平台的 dll, 就會變成循環參考, 所以才會採取這個作法
        /// </summary>
        /// <param name="services"></param>
        public static void AddApplicationParts(this IServiceCollection services)
        {
            foreach (string platform in platforms)
            {
                var apiAssembly = Assembly.LoadFrom(Path.Combine(_dirPath, $"BackendPlatform.API.{platform}.dll"));
                var serviceAssembly = Assembly.LoadFrom(Path.Combine(_dirPath, $"BackendPlatform.Service.{platform}.dll"));

                services.AddMvc().AddApplicationPart(apiAssembly).AddControllersAsServices();
                services.AddMvc().AddApplicationPart(serviceAssembly);
            }
        }

        /// <summary>
        /// 註冊 Http 用戶端
        /// </summary>
        /// <param name="services"></param>
        public static void AddHttpClients(this IServiceCollection services)
        {
            // 把每個 API 服務的基本參數在這裡設定
            services.AddHttpClient(HttpClientNames.W1, client => 
            {
                client.BaseAddress = new Uri("http://traefik-internal.w1-traefik-dev/w1api/");
                client.Timeout = TimeSpan.FromSeconds(5);
            });
        }

        /// <summary>
        /// 客製化 Input Model 欄位驗證失敗的回應
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddCustomModelBindingFailResponse(this IServiceCollection services)
        {
            return services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    // model validation 失敗的話一樣回應200, 要調整的話再改就好
                    return new OkObjectResult(new ServiceResponseModel
                    {
                        Code = 1, //ErrorCodeEnum.InputValidationFailure,
                        Message = GetFirstErrorMsg(context.ModelState.Values)
                    });
                };
            });

            // 抓第一個錯誤訊息
            string GetFirstErrorMsg(ValueEnumerable values)
            {
                var msg = string.Empty;
                foreach (var v in values)
                {
                    if (v.Errors.Count > 0)
                    {
                        msg = v.Errors[0].ErrorMessage;
                        break;
                    }
                }
                return msg;
            }
        }
    }
}
