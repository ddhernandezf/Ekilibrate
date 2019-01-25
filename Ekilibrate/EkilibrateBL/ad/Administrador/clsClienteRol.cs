using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Administrador;
using Ekilibrate.Model.Administrador;

namespace Ekilibrate.ad.Administrador
{
    public class clsClienteRol : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsClienteRolBase, Int32>
    {
        public clsClienteRol(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Insert(clsClienteRolBase Data)
        {
            var p = new DynamicParameters();
            p.Add("Nombre", Data.Nombre, System.Data.DbType.String);
            return await SetWithResult<Int32>(p, QSalon.Insert);
        }

        public async Task Update(clsClienteRolBase Data)
        {
            var p = new DynamicParameters();
            p.Add("Id",  Data.Id, System.Data.DbType.Int32);
            p.Add("Nombre", Data.Nombre, System.Data.DbType.String);
            await Set(p, QSalon.Update);
        }

        public async Task Delete(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, System.Data.DbType.Int32);
            await Set(p, QSalon.Delete);
        }
    }
}
