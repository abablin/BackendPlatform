using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Configuration;
using System.Security.Claims;
using BackendPlatform.Core.Helpers;

namespace BackendPlatform.API.Extensions
{
    public static class UserInfoLoggerExtensions
    {
        /// <summary>
        /// 添加 Serilog 預設的輸出值
        /// </summary>
        /// <param name="enrichmentConfiguration"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static LoggerConfiguration WithUserInfo(this LoggerEnrichmentConfiguration enrichmentConfiguration)
        {
            if (enrichmentConfiguration == null)
            {
                throw new NotImplementedException("Logger Enrichment Configuration");
            }

            return enrichmentConfiguration.With<UserInfoEnricher>();
        }

        public sealed class UserInfoEnricher : ILogEventEnricher
        {
            private readonly IHttpContextAccessor _contextAccessor;

            public UserInfoEnricher() : this(new HttpContextAccessor()) { }

            internal UserInfoEnricher(IHttpContextAccessor contextAccessor)
            {
                _contextAccessor = contextAccessor;
            }

            public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
            {
                var httpContext = _contextAccessor.HttpContext;

                if (httpContext is not null)
                {
                    var role = httpContext.User.Identity.IsAuthenticated ? httpContext.User.FindFirst(ClaimTypes.Role).Value : "未登入";
                    var account = httpContext.User.Identity.IsAuthenticated ? httpContext.User.FindFirst(ClaimTypes.Name).Value : "未登入";

                    var dicProperties = new Dictionary<string, string>(4);
                    dicProperties.Add("Role", role);
                    dicProperties.Add("Account", account);
                    dicProperties.Add("IP", ApplicationHelper.GetClientIP(httpContext));
                    dicProperties.Add("UserAgent", ApplicationHelper.GetClientUserAgent(httpContext));

                    dicProperties.Select(x => new LogEventProperty(x.Key, new ScalarValue(x.Value)))
                        .ToList()
                        .ForEach(x => logEvent.AddPropertyIfAbsent(x));
                }
            }
        }
    }
}
