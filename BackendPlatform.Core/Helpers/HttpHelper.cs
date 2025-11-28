using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendPlatform.Core.Helpers
{
    public sealed class HttpHelper
    {
        private readonly IHttpClientFactory _factory;

        public HttpHelper(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<string> Get(string clientName, string url, int timeout = 5)
        {
            var result = string.Empty;

            try
            {                
                using var client = _factory.CreateClient(clientName);
                client.Timeout = TimeSpan.FromSeconds(timeout);

                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            catch(Exception ex)
            {
                string s = ex.Message;

                // Log 輸出
            }

            return result;
        }
    }
}
