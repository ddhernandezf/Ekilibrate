using Dapper;
using Autofac;
using Ekilibrate.Data.EntityModel.Abstract;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;


namespace Ekilibrate.Data.Access.Common
{
    public abstract class clsReadOnlyDataAccess<TEntity, TKey> : clsDataAccess<TEntity, TKey> where TEntity : IEntityPOCO<TKey>, new()
    {
        public clsReadOnlyDataAccess(ILifetimeScope lifetimeScope)
            : base(lifetimeScope)
        { }

        private async Task<IEnumerable<T>> Query<T>(Func<IDbConnection, Task<IEnumerable<T>>> getData)
        {
            try
            {
                using (var _conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlServerPool"].ConnectionString))
                {
                    await _conn.OpenAsync();
                    return await getData(_conn);
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception("Venció el tiempo de espera al intentar abrir la base de datos", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al ejecutar SQL", ex);
            }
        }

        private async Task<IEnumerable<TEntity>> Query(Func<IDbConnection, Task<IEnumerable<TEntity>>> getData)
        {
            try
            {
                using (var _conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["SqlServerPool"].ConnectionString))
                {
                    await _conn.OpenAsync();
                    return await getData(_conn);
                }
            }
            catch (TimeoutException ex)
            {
                throw new Exception("Venció el tiempo de espera al intentar abrir la base de datos", ex);
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al ejecutar SQL", ex);
            }
        }

        protected async Task<IEnumerable<TEntity>> Get(DynamicParameters param, String query)
        {
            try
            {
                return await Query(async c =>
                {
                    var result = await c.QueryAsync<TEntity>(
                        sql: query,
                        commandType: System.Data.CommandType.Text,
                        param: param);
                    return result;
                });
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                throw ex;
            }
        }

        protected async Task<IEnumerable<T>> Get<T>(DynamicParameters param, String query)
        {
            try
            {
                return await Query<T>(async c =>
                {
                    var result = await c.QueryAsync<T>(
                        sql: query,
                        commandType: System.Data.CommandType.Text,
                        param: param);
                    return result;
                });
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                throw ex;
            }
        }
    }
}
