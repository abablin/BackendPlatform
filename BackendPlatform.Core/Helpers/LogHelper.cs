using Serilog;
using m = Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;

namespace BackendPlatform.Core.Helpers
{
    public static class LogHelper
    {
        private static m.ILogger _logger;
        private static Dictionary<LogLevel, Action<string, object?[]>> dicMethods;

        static LogHelper()
        {
            _logger = ApplicationLogging.CreateLogger("LogHelper");

            dicMethods = new Dictionary<LogLevel, Action<string, object?[]>>(8);
            dicMethods.Add(LogLevel.Information, _logger.LogInformation);
            dicMethods.Add(LogLevel.Warning, _logger.LogWarning);
            dicMethods.Add(LogLevel.Error, _logger.LogError);
            dicMethods.Add(LogLevel.Critical, _logger.LogCritical);
        }

        /// <summary>
        /// 輸出 Log
        /// 目前只提供部分Level, 需要再加
        /// </summary>
        /// <param name="level"></param>
        /// <param name="msg"></param>
        /// <param name="input"></param>
        public static void Log(LogLevel level, string msg, object input)
        {
            _ = dicMethods.TryGetValue(level, out var method);

            if (method is not null)
            {
                method("訊息:{msg}, 請求:{@input}", new object[] { msg, input });
            }
        }
    }

    public static class ApplicationLogging
    {
        public static ILoggerFactory LoggerFactory { get; set; } =
        (LoggerFactory)Serilog.SerilogLoggerFactoryExtensions.AddSerilog
        (
            new LoggerFactory(),
            Serilog.Log.Logger
        );

        public static m.ILogger CreateLogger(string name)
        {
            return LoggerFactory.CreateLogger(name);
        }

        public static void LoadLogSetting(HostBuilderContext context, IServiceProvider services, LoggerConfiguration config)
        {
            config.ReadFrom.Configuration(context.Configuration)
                .ReadFrom.Services(services)
                //.Enrich.WithUserInfo()
                .Enrich.FromLogContext();
        }
    }
}
