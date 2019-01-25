using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Administrador;
using Ekilibrate.Model.Entity.Administrador;

namespace Ekilibrate.ad.Administrador
{
    public class clsSalon : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsSalonBase, Int32>
    {
        public clsSalon(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Insert(clsSalonBase Data)
        {
            var p = new DynamicParameters();
            p.Add("Nombre", Data.Nombre, System.Data.DbType.String);
            p.Add("Capacidad", Data.Capacidad, System.Data.DbType.String);
            p.Add("TipoUsoId", Data.TipoUsoId, System.Data.DbType.Int32);
            p.Add("EmpresaId", Data.EmpresaId, System.Data.DbType.Int32);
            return await SetWithResult<Int32>(p, QSalon.Insert);
        }

        public async Task Update(clsSalonBase Data)
        {
            var p = new DynamicParameters();
            p.Add("Id",  Data.Id, System.Data.DbType.Int32);
            p.Add("Nombre", Data.Nombre, System.Data.DbType.String);
            p.Add("Capacidad", Data.Capacidad, System.Data.DbType.String);
            p.Add("TipoUsoId", Data.TipoUsoId, System.Data.DbType.Int32);
            p.Add("EmpresaId", Data.EmpresaId, System.Data.DbType.Int32);
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
