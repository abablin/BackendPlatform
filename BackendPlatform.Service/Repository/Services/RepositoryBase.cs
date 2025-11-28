using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using BackendPlatform.Service.Repository.Interfaces;

namespace BackendPlatform.Service.Repository.Services
{
    public sealed class DbContextFactory
    {
        public IDbConnection GetConnection(string? connectionString = null)
        {
            return new SqlConnection(connectionString ?? "帶入預設連線字串");
        }
    }

    public class RepositoryBase : IRepositoryBase
    {

        protected readonly string _connDefault;
        protected readonly DbContextFactory _factory;

        public RepositoryBase()
        {
            _connDefault = "";
            _factory = new DbContextFactory();
        }

        public async Task<int> ExecuteAsync(string cmd, DynamicParameters param, bool isSP = false, string? cn = null)
        {
            return await this._factory.GetConnection(cn ?? this._connDefault).ExecuteAsync(cmd, param, commandType: isSP ? CommandType.StoredProcedure : CommandType.Text);
        }

        public async Task<T> ExecuteScalarAsync<T>(string cmd, DynamicParameters param, bool isSP = false, string? cn = null)
        {
            return await this._factory.GetConnection(cn ?? this._connDefault).ExecuteScalarAsync<T>(cmd, param, commandType: isSP ? CommandType.StoredProcedure : CommandType.Text);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string cmd, bool isSP = false, string? cn = null)
        {
            return await QueryAsync<T>(cmd, null, isSP, cn);
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string cmd, DynamicParameters? param, bool isSP = false, string? cn = null)
        {
            return await this._factory.GetConnection(cn ?? this._connDefault).QueryAsync<T>(cmd, param, commandType: isSP ? CommandType.StoredProcedure : CommandType.Text);
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string cmd, DynamicParameters param, bool isSP = false, string? cn = null)
        {
            return await this._factory.GetConnection(cn ?? this._connDefault).QueryFirstOrDefaultAsync<T>(cmd, param, commandType: isSP ? CommandType.StoredProcedure : CommandType.Text);
        }

        public async Task<SqlMapper.GridReader> QueryMultipleAsync(string cmd, bool isSP = false, string? cn = null)
        {
            return await QueryMultipleAsync(cmd, null, isSP, cn);
        }

        public async Task<SqlMapper.GridReader> QueryMultipleAsync(string cmd, DynamicParameters? param, bool isSP = false, string? cn = null)
        {
            return await this._factory.GetConnection(cn ?? this._connDefault).QueryMultipleAsync(cmd, param, commandType: isSP ? CommandType.StoredProcedure : CommandType.Text);
        }

        public async Task<T> QuerySingleAsync<T>(string cmd, Dictionary<string, object> param, bool isSP = false, string? cn = null)
        {
            return await this._factory.GetConnection(cn ?? this._connDefault).QuerySingleAsync<T>(cmd, param, commandType: isSP ? CommandType.StoredProcedure : CommandType.Text);
        }

        public async Task<T> QuerySingleAsync<T>(string cmd, DynamicParameters param, bool isSP = false, string? cn = null)
        {
            return await this._factory.GetConnection(cn ?? this._connDefault).QuerySingleAsync<T>(cmd, param, commandType: isSP ? CommandType.StoredProcedure : CommandType.Text);
        }
    }
}
