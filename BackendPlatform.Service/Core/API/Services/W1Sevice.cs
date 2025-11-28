using System.Text;
using System.Text.Encodings.Web;
using BackendPlatform.Core.Helpers;
using BackendPlatform.Core.ConstData;
using Microsoft.Extensions.DependencyInjection;
using BackendPlatform.Service.Core.API.Interfaces;

namespace BackendPlatform.Service.Core.API.Services
{
    public class APISeviceBase
    {
        protected readonly HttpHelper _httpHelper;

        public APISeviceBase(IServiceProvider provider)
        {
            using (var scope = provider.CreateScope())
            {
                _httpHelper = scope.ServiceProvider.GetRequiredService<HttpHelper>();
            }
        }
    }

    public sealed class W1Sevice : IW1Sevice
    {
        private readonly HttpHelper _httpHelper;

        public W1Sevice(HttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        // *********************
        public HttpHelper Helper { get; set; }

        public async Task<string> GetBetDetail(string record_id, string platform, string lang, string reportTime, string otherParam = "")
        {
            var sb = new StringBuilder(128);
            sb.Append($"record_id={record_id}");
            sb.Append($"&Platform={platform}");
            sb.Append($"&lang={lang}");
            sb.Append($"&ReportTime={UrlEncoder.Default.Encode(reportTime)}");
            sb.Append(otherParam);

            return await Get($"GetBetDetail?{sb.ToString()}");
        }

        public async Task<string> GetBetRecord(string summary_id, string platform, string reportTime, string clubID)
        {
            var sb = new StringBuilder(128);
            sb.Append($"summary_id={summary_id}");
            sb.Append($"&Platform={platform}");
            sb.Append($"&ReportTime={UrlEncoder.Default.Encode(reportTime)}");
            sb.Append($"&ClubId={clubID}");

            return await Get($"GetBetRecord?{sb.ToString()}");
        }

        public async Task<string> GetBetRecordUnsettle(string thirdPartyID, string clubID, string startTime, string endTime)
        {
            var sb = new StringBuilder(128);
            sb.Append($"Platform={thirdPartyID}");
            sb.Append($"&Club_id={clubID}");
            sb.Append($"&StartTime={startTime}");
            sb.Append($"&EndTime={endTime}");

            return await Get($"GetBetRecordUnsettle?{sb.ToString()}");
        }

        public async Task<string> GetRowData(string record_id, string lang, string reportTime, string platform = "WM")
        {
            var sb = new StringBuilder(128);
            sb.Append($"record_id={record_id}");
            sb.Append($"&Platform={platform}");
            sb.Append($"&lang={lang}");
            sb.Append($"&ReportTime={UrlEncoder.Default.Encode(reportTime)}");

            return await Get($"GetRowData?{sb.ToString()}");
        }

        public async Task<string> GetRowData(string record_id, string lang, string reportTime, string summary_id, string platform = "WM")
        {
            var sb = new StringBuilder(128);
            sb.Append($"record_id={record_id}");
            sb.Append($"&Platform={platform}");
            sb.Append($"&lang={lang}");
            sb.Append($"&ReportTime={reportTime}");
            sb.Append($"&summary_id={summary_id}");

            return await Get($"GetRowData?{sb.ToString()}");
        }

        public async Task<string> UserWalletSession(string clubID)
        {
            return await Get($"UserWalletSession?Club_id={clubID}");
        }

        private async Task<string> Get(string url)
        {
            return await Helper.Get(HttpClientNames.W1, url);
        }
    }
}
