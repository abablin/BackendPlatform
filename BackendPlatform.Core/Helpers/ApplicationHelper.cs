using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace BackendPlatform.Core.Helpers
{
    public static class ApplicationHelper
    {
        private static readonly Dictionary<string, int> _dicMapping;

        static ApplicationHelper()
        {
            //_dicMapping = new Dictionary<string, int>(2);
            //_dicMapping.Add(ApplicationNames.LucyCtrl.ToLower(), (int)ApplicationIDs.LucyCtrl);
            //_dicMapping.Add(ApplicationNames.Lucy.ToLower(), (int)ApplicationIDs.Lucy);
        }

        /// <summary>
        /// 取得應用程式編號
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public static int GetApplicationId(string application)
        {
            _ = _dicMapping.TryGetValue(application.ToLower(), out int id);
            return id;
        }

        /// <summary>
        /// 判斷傳入的應用程式名稱是否為有效
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public static bool IsValidApplication(string application)
        {
            return _dicMapping.ContainsKey(application.ToLower());
        }

        /// <summary>
        /// 讀取請求來源的 IP
        /// </summary>
        /// <param name="conetxt"></param>
        /// <returns></returns>
        public static string GetClientIP(HttpContext conetxt)
        {
            if (conetxt.Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                // 抓逗號隔開的第一個才是 Client IP, 後面的是 Proxy IP
                return conetxt.Request.Headers["X-Forwarded-For"].ToString().Split(',')[0];
            }
            else
            {
                return conetxt.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
        }

        /// <summary>
        /// 讀取請求來源的 User Agent
        /// </summary>
        /// <param name="conetxt"></param>
        /// <returns></returns>
        public static string GetClientUserAgent(HttpContext conetxt)
        {
            if (conetxt.Request.Headers.ContainsKey(HeaderNames.UserAgent))
            {
                return conetxt.Request.Headers[HeaderNames.UserAgent].ToString();
            }
            else
            {
                return "Not found";
            }
        }
    }
}
