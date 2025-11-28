using Dapper;

namespace BackendPlatform.Service.Repository.Interfaces
{
    public interface IRepositoryBase
    {
        /// <summary>
        /// 執行命令, 並回傳受影響的資料筆數 (SQL語法/SP名稱, 帶參數)
        /// </summary>
        /// <param name="cmd">SQL語法/SP名稱</param>
        /// <param name="param">參數物件</param>
        /// <param name="isSP">是否為執行SP, 預設為 false</param>
        /// <param name="cn">連線字串</param>
        /// <returns></returns>
        Task<int> ExecuteAsync(string cmd, DynamicParameters param, bool isSP = false, string? cn = null);

        /// <summary>
        /// 查詢集合資料 (SQL語法/SP名稱, 不帶參數)
        /// </summary>
        /// <typeparam name="T">要回傳的資料型態</typeparam>
        /// <param name="cmd">SQL語法/SP名稱</param>
        /// <param name="isSP">是否為執行SP, 預設為 false</param>
        /// <param name="cn">連線字串</param>
        /// <returns></returns>
        Task<IEnumerable<T>> QueryAsync<T>(string cmd, bool isSP = false, string? cn = null);

        /// <summary>
        /// 查詢集合資料 (SQL語法/SP名稱, 帶參數)
        /// </summary>
        /// <typeparam name="T">要回傳的資料型態</typeparam>
        /// <param name="cmd">SQL語法/SP名稱</param>
        /// <param name="param">參數物件</param>
        /// <param name="isSP">是否為執行SP, 預設為 false</param>
        /// <param name="cn">連線字串</param>
        /// <returns></returns>
        Task<IEnumerable<T>> QueryAsync<T>(string cmd, DynamicParameters param, bool isSP = false, string? cn = null);

        /// <summary>
        /// 查詢單一筆資料 (SQL語法/SP名稱, 帶字典參數)
        /// </summary>
        /// <typeparam name="T">要回傳的資料型態</typeparam>
        /// <param name="cmd">SQL語法/SP名稱</param>
        /// <param name="param">參數物件</param>
        /// <param name="isSP">是否為執行SP, 預設為 false</param>
        /// <param name="cn">連線字串</param>
        /// <returns></returns>
        Task<T> QuerySingleAsync<T>(string cmd, Dictionary<string, object> param, bool isSP = false, string? cn = null);

        /// <summary>
        /// 查詢單一筆資料 (SQL語法/SP名稱, 帶參數)
        /// </summary>
        /// <typeparam name="T">要回傳的資料型態</typeparam>
        /// <param name="cmd">SQL語法/SP名稱</param>
        /// <param name="param">參數物件</param>
        /// <param name="isSP">是否為執行SP, 預設為 false</param>
        /// <param name="cn">連線字串</param>
        /// <returns></returns>
        Task<T> QuerySingleAsync<T>(string cmd, DynamicParameters param, bool isSP = false, string? cn = null);

        /// <summary>
        /// 查詢第一筆資料 (SQL語法/SP名稱, 帶參數)
        /// </summary>
        /// <typeparam name="T">第一筆資料型態</typeparam>
        /// <param name="cmd">SQL語法/SP名稱</param>
        /// <param name="param">參數物件</param>
        /// <param name="isSP">是否為執行SP, 預設為 false</param>
        /// <param name="cn">連線字串, 預設值:SQLServer.Default</param>
        /// <returns></returns>
        Task<T> QueryFirstOrDefaultAsync<T>(string cmd, DynamicParameters param, bool isSP = false, string? cn = null);

        /// <summary>
        /// 查詢多個結果集 (SQL語法/SP名稱, 不帶參數)
        /// </summary>
        /// <param name="cmd">SQL語法/SP名稱</param>
        /// <param name="isSP">是否為執行SP, 預設為 false</param>
        /// <param name="cn">連線字串</param>
        /// <returns></returns>
        Task<SqlMapper.GridReader> QueryMultipleAsync(string cmd, bool isSP = false, string? cn = null);

        /// <summary>
        /// 查詢多個結果集 (SQL語法/SP名稱, 帶參數)
        /// </summary>
        /// <param name="cmd">SQL語法/SP名稱</param>
        /// <param name="param">參數物件</param>
        /// <param name="isSP">是否為執行SP, 預設為 false</param>
        /// <param name="cn">連線字串</param>
        /// <returns></returns>
        Task<SqlMapper.GridReader> QueryMultipleAsync(string cmd, DynamicParameters param, bool isSP = false, string? cn = null);

        /// <summary>
        /// 查詢單一值 (SQL語法/SP名稱, 帶參數)
        /// </summary>
        /// <typeparam name="T">單一值型態</typeparam>
        /// <param name="cmd">SQL語法/SP名稱</param>
        /// <param name="param">參數物件</param>
        /// <param name="isSP">是否為執行SP, 預設為 false</param>
        /// <param name="cn">連線字串</param>
        /// <returns></returns>
        Task<T> ExecuteScalarAsync<T>(string cmd, DynamicParameters param, bool isSP = false, string? cn = null);
    }
}
