//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace BackendPlatform.Core.ConstData
{
    /// <summary>
    /// 把選單列表寫在這裡
    /// 後續如果有分上下層選單, 在這邊加入 inner class 區分就好
    /// </summary>
    public static class FunctionSetList
    {
        /// <summary>
        /// 子帳號
        /// </summary>
        public const string SubAccount = "subAccount";

        /// <summary>
        /// 總監
        /// </summary>
        public const string Director = "director";

        /// <summary>
        /// 大股東
        /// </summary>
        public const string MajorShareHolder = "majorShareHolder";

        /// <summary>
        /// 股東
        /// </summary>
        public const string MinorShareHolder = "minorShareHolder";

        /// <summary>
        /// 總代理
        /// </summary>
        public const string GeneralAgent = "generalAgent";

        /// <summary>
        /// 代理
        /// </summary>
        public const string Agent = "agent";

        /// <summary>
        /// 會員
        /// </summary>
        public const string Club = "club";

        /// <summary>
        /// 個人資料
        /// </summary>
        public const string AccountDetail = "AccountDetail";

        /// <summary>
        /// 即時押分
        /// </summary>
        public const string OnlineBet = "onlineBet";

        /// <summary>
        /// 批量操作 (母選單)
        /// </summary>
        public const string Batch = "batch";

        /// <summary>
        /// Google Key 兩階段驗證
        /// </summary>
        public const string TFASetting = "tfaSetting";

        /// <summary>
        /// 報表
        /// </summary>
        public static class Reports
        {
            /// <summary>
            /// 開牌記錄
            /// </summary>
            public const string Openlist = "openlist";

            /// <summary>
            /// 輸贏報表
            /// </summary>
            public const string Search = "search";

            /// <summary>
            /// 未結算報表
            /// </summary>
            public const string Unsettled = "unsettled";
        }

        /// <summary>
        /// 紀錄查詢
        /// </summary>
        public static class RecordsQuery
        {
            /// <summary>
            /// 充值紀錄查詢
            /// </summary>
            public const string WalletChargeLog = "walletChargeLog";

            /// <summary>
            /// 操作紀錄
            /// </summary>
            public const string OperationLog = "operationLog";

            /// <summary>
            /// 額度紀錄
            /// </summary>
            public const string WalletTransferLog = "WalletTransferLog";

            /// <summary>
            /// 登入紀錄
            /// </summary>
            public const string LoginLog = "loginLog";
        }

        /// <summary>
        /// 系統公告
        /// </summary>
        public static class SystemBulletin
        {
            /// <summary>
            /// 公告清單
            /// </summary>
            public const string Bulletin = "Bulletin";

            /// <summary>
            /// 公告清單
            /// </summary>
            public const string BulletinList = "bulletinList";

            /// <summary>
            /// 公告管理
            /// </summary>
            public const string BulletinManage = "bulletinManage";
        }

        /// <summary>
        /// 角色權限管理
        /// </summary>
        public static class RoleAndPermission
        {
            /// <summary>
            /// 角色管理
            /// </summary>
            public const string RoleManage = "roleManage";

            /// <summary>
            /// 選單管理
            /// </summary>
            public const string FunctionManage = "functionManage";
        }

        /// <summary>
        /// 基本資料
        /// </summary>
        public static class BasicData
        {
            /// <summary>
            /// 多語系資料
            /// </summary>
            public const string LangManage = "langManage";

            /// <summary>
            /// 快取資料
            /// </summary>
            public const string CacheManage = "cacheManage";
        }

        /// <summary>
        /// 金流管理
        /// </summary>
        public static class CashFlow
        {
            /// <summary>
            /// 銀行卡管理
            /// </summary>
            public const string SiteBankAccount = "siteBankAccount";

            /// <summary>
            /// 存款單
            /// </summary>
            public const string DepositForm = "depositForm";

            /// <summary>
            /// 取款單
            /// </summary>
            public const string WithdrawForm = "withdrawForm";

            /// <summary>
            /// 會員銀行卡管理
            /// </summary>
            public const string MemberBankAccount = "memberBankAccount";

            /// <summary>
            /// 活動設定
            /// </summary>
            public const string ActivitySetting = "activitySetting";

            /// <summary>
            /// 金流平台設定
            /// </summary>
            public const string AutoCashProvider = "autoCashProvider";

            /// <summary>
            /// 洗碼單
            /// </summary>
            public const string WashOrder = "washOrder";

            /// <summary>
            /// 交易紀錄查詢
            /// </summary>
            public const string TransactionLog = "transactionLog";

            /// <summary>
            /// 會員批量設定
            /// </summary>
            public const string ClubSetting = "clubSetting";
        }

        /// <summary>
        /// 角色權限管理 (控端)
        /// </summary>
        public static class RoleAndPermission_Manager
        {
            /// <summary>
            /// 角色管理
            /// </summary>
            public const string RoleManage = "roleManage_Manager";

            /// <summary>
            /// 選單管理
            /// </summary>
            public const string FunctionManage = "functionManage_Manager";

            /// <summary>
            /// 帳號管理
            /// </summary>
            public const string AccountManage = "accountManage_Manager";
        }

        /// <summary>
        /// 批次作業
        /// </summary>
        public static class BatchOperation
        {
            /// <summary>
            /// 批量新增 (代理)
            /// </summary>
            public const string InsertFranchiser = "batchInsertF";

            /// <summary>
            /// 批量新增 (會員)
            /// </summary>
            public const string InsertClub = "batchInsertC";

            /// <summary>
            /// 批量充值
            /// </summary>
            public const string Deposit = "batchDeposit";

            /// <summary>
            /// 批量提取
            /// </summary>
            public const string Withdraw = "batchWithdraw";

            /// <summary>
            /// 帳號狀況
            /// </summary>
            public const string ClubStatus = "batchClubStatus";

            /// <summary>
            /// 遊戲開放
            /// </summary>
            public const string GameOpen = "batchGameOpen";
        }

        /// <summary>
        /// 不指定選單名稱, 名稱資料從路由的路徑抓
        /// 必須搭配下面這樣的路由, 要加入 {feature} 區段 (沒有限制一定要在最後面, 但一定要加進來, 不分大小寫)
        /// 例如 [Route("BetSettings/Update/Bacc/{feature}")]
        /// </summary>
        public const string FromRoute = "FromRoute";
    }
}
