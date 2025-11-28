using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackendPlatform.Core.ConstData;
using BackendPlatform.Core.Helpers;

namespace BackendPlatform.Service.Core.API.Interfaces
{
    public interface IAPIService 
    {
        HttpHelper Helper { get; set; }
    }

    public interface IW1Sevice: IAPIService
    {
        Task<string> GetBetRecord(string summary_id, string platform, string reportTime, string clubID);
        Task<string> GetBetDetail(string record_id, string platform, string lang, string reportTime, string otherParam = "");
        Task<string> GetBetRecordUnsettle(string thirdPartyID, string clubID, string startTime, string endTime);
        Task<string> UserWalletSession(string clubID);
        Task<string> GetRowData(string record_id, string lang, string reportTime, string platform = W1ThirdPartyID.WM);
        Task<string> GetRowData(string record_id, string lang, string reportTime, string summary_id, string platform = W1ThirdPartyID.WM);
    }
}
