using Microsoft.Extensions.Configuration;

namespace BackendPlatform.Core.Models
{
    public static class AppSettings
    {
        #region Field
        private static IConfiguration _config;
        private static FullRich _fullRich;
        private static Environment _environment = new Environment();
        #endregion

        #region Property
        public static FullRich FullRich => _fullRich;
        public static Environment Environment => _environment;

        public static IConfiguration Configuration
        {
            get { return _config; }
            set
            {
                _config = value;
                _fullRich = value.GetSection("FullRich").Get<FullRich>();
            }
        }
        #endregion
    }

    #region 相關類別物件 - FullRich
    public sealed class FullRich
    {
        public DatabaseConfig Database { get; set; }

        public GameSetting GameSetting { get; set; }
    }
    public sealed class GameSetting
    {
        /// <summary>
        /// 記錄第三方的遊戲廠商名稱, 例如RTG,JDB等
        /// </summary>
        public string ThirdPartyIDList { get; set; }

        /// <summary>
        /// 輸贏報表中, 在最底層注單明細中, JDB遊戲用的連結
        /// </summary>
        public string JDBBetDetailLink { get; set; }

        /// <summary>
        /// 新增代理階層後,會呼叫的第三方API網址 (公司內部的)
        /// </summary>
        public string AppAPIURL { get; set; }

        public RoyalEGame RoyalEGame { get; set; }

        public H1 H1 { get; set; }

        public W1 W1 { get; set; }

        public H1_PC H1_PC { get; set; }

        public JDBEGame JDBEGame { get; set; }

        public GClub GClub { get; set; }
        public RTG RTG { get; set; }

        public RCG RCG { get; set; }
    }
    public sealed class RoyalEGame
    {
        public string S2ToolsUrl { get; set; }
        public string S2List { get; set; }
        public string S2FishList { get; set; }
        public string S2SubSystem { get; set; }
        public string S3ToolsUrl { get; set; }
        public string S3SubSystem { get; set; }
        public string S3SubSystemCLine { get; set; }
        public string S3TimeFlag { get; set; }

        /// <summary>
        /// RSG 走 W1 轉帳模式的帳務起始時間
        /// </summary>
        public string W1ModeStartDate { get; set; }
    }
    public sealed class H1
    {
        public string WalletAPIURL { get; set; }
        public string BetRecordNowURL { get; set; }
    }
    public sealed class W1
    {
        public string WalletAPIURL { get; set; }
    }
    public sealed class H1_PC
    {
        public string APIURL { get; set; }
    }
    public sealed class JDBEGame
    {
        public string S2ToolsUrl { get; set; }
    }
    public sealed class GClub
    {
        public string ApiUrl { get; set; }
        public string ApiSecretKey { get; set; }
    }
    public sealed class RTG
    {
        public string ApiUrl { get; set; }
        public string SystemCode { get; set; }
        public string WebId { get; set; }
        public string SystemCodeDLine { get; set; }
        public string WebIdDLine { get; set; }
        public string DesKey { get; set; }
        public string DesIV { get; set; }
        public string XApiClientID { get; set; }
        public string ClientSecret { get; set; }
    }
    public sealed class RCG
    {
        public string ApiUrl { get; set; }
        public string ApiV2Url { get; set; }
        public string DesKey { get; set; }
        public string DesIV { get; set; }
        public string XApiClientID { get; set; }
        public string ClientSecret { get; set; }
    }
    public sealed class DatabaseConfig
    {
        /// <summary>
        /// 是否在 console 顯示 sql command
        /// </summary>
        public bool ShowCommand { get; set; }

        /// <summary>
        /// SQLServer or SQLite
        /// </summary>
        public string Provider { get; set; }

        /// <summary>
        /// 使用 SQL Server 時的設定
        /// </summary>
        public DatabaseSetting SQLServer { get; set; }
    }
    public sealed class DatabaseSetting
    {
        /// <summary>
        /// 日帳
        /// </summary>
        public string Default { get; set; }

        /// <summary>
        /// 日同步
        /// </summary>
        public string Cur { get; set; }

        /// <summary>
        /// 月帳
        /// </summary>
        public string Mon { get; set; }

        /// <summary>
        /// 月同步
        /// </summary>
        public string Mon2 { get; set; }
    }
    public sealed class Environment
    {
        private string _environmentName;

        /// <summary>
        /// 環境名稱
        /// 例如 DEV,UAT,PRD,Development
        /// </summary>
        public string EnvironmentName
        {
            get { return _environmentName.StartsWith("K8S") ? _environmentName.Substring(3) : _environmentName; }
            set { _environmentName = value; }
        }
    }
    #endregion
}
