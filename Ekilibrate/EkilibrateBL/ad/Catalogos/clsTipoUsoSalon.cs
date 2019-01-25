using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Catalogos;
using Ekilibrate.Model.Catalogos;

namespace Ekilibrate.ad.Catalogos
{
    public class clsTipoUsoSalon : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsTipoUsoSalonBase, Int32>
    {
        public clsTipoUsoSalon(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Insert(clsTipoUsoSalonBase Data)
        {
            var p = new DynamicParameters();
            p.Add("Nombre", Data.Nombre, System.Data.DbType.String);
            return await SetWithResult<Int32>(p, QTipoUsoSalon.Insert);
        }

        public async Task Update(clsTipoUsoSalonBase Data)
        {
            var p = new DynamicParameters();
            p.Add("Id",  Data.Id, System.Data.DbType.Int32);
            p.Add("Nombre", Data.Nombre, System.Data.DbType.String);
            await Set(p, QTipoUsoSalon.Update);
        }

        public async Task Delete(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, System.Data.DbType.Int32);
            await Set(p, QTipoUsoSalon.Delete);
        }
    }
}
