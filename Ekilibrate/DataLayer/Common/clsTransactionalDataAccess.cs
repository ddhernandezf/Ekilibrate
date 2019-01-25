using Dapper;
using Autofac;
using Ekilibrate.Data.EntityModel.Abstract;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Ekilibrate.Data.Access.Common
{
    abstract public class clsTransactionalDataAccess<TEntity, TKey> : clsDataAccess<TEntity, TKey> where TEntity : IEntityPOCO<TKey>, new()
    {
        public clsTransactionalDataAccess(ILifetimeScope lifetimeScope): base(lifetimeScope)
        {
        }

        private async Task<IEnumerable<TEntity>> Query(Func<IDbConnection, IDbTransaction, Task<IEnumerable<TEntity>>> getData)
        {
            return await ExecuteWithResult<IEnumerable<TEntity>>(getData);
        }

        private async Task<bool> Execute(Func<IDbConnection, IDbTransaction, Task<bool>> getData)
        {
            return await ExecuteWithResult<bool>(getData);
        }

        private async Task<TResult> ExecuteWithResult<TResult>(Func<IDbConnection, IDbTransaction, Task<TResult>> getData)
        {
            try
            {
                    var DBContext = base._lifetimescope.Resolve<DBTrnContext>();
                    return await getData(DBContext.Conn, DBContext.Trn);
                
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

        protected async Task<bool> Set(DynamicParameters param, String query)
        {
            try
            { 
                bool res = await Execute(async (c, t) =>
                {
                    try
                    {
                       var result = await c.ExecuteAsync(sql: query,
                       param: param,
                       transaction: t,
                       commandType: System.Data.CommandType.Text);
                        return result == 1;
                    }
                    catch (Exception ex)
                    {
                        Console.Write(ex.ToString());
                        throw ex;
                    }
                });
                return res;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                throw ex;
            }
        }

        protected async Task<TResult> SetWithResult<TResult>(DynamicParameters param, String query) where TResult : new()
        {
            return await ExecuteWithResult<TResult>(async (c, t) =>
            {
                try
                {
                    IEnumerable<TResult> result = await c.QueryAsync<TResult>(sql: query,
                        param: param,
                        transaction: t,
                        commandType: System.Data.CommandType.Text);
                    return result.FirstOrDefault();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                    throw ex;
                }
            });
        }

        protected async Task<IEnumerable<TEntity>> Get(DynamicParameters param, String query)
        {
            return await Query(async (c, t) =>
            {
                try
                {
                    var result = await c.QueryAsync<TEntity>(sql: query,
                        param: param,
                        transaction: t,
                        commandType: System.Data.CommandType.Text);
                    return result;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                    throw ex;
                }
            });
        }
    }
}
