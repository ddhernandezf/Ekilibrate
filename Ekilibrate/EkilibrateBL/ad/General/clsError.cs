using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.General;
using Ekilibrate.Model.Entity.General;

namespace Ekilibrate.ad.General
{
    public class clsError : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Error, Int32>
    {
        public clsError(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Insert(Error Data)
        {
            var p = new DynamicParameters();
            p.Add("Mensaje", Data.Mensaje, System.Data.DbType.String);
            p.Add("Pila", Data.Pila, System.Data.DbType.String);
            p.Add("Excepcion", Data.Excepcion, System.Data.DbType.String);
            p.Add("Fecha", Data.Fecha, System.Data.DbType.DateTime);
            await Set(p, QError.Insert);
        }
    }
}
