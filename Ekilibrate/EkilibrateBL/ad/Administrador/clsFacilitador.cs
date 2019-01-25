using Autofac;
using Dapper;
using Ekilibrate.Model.Entity.Administrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.ad.Administrador
{
    public class clsFacilitador : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsFacilitadorBase, Int32>
    {
        public clsFacilitador(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Insert(clsFacilitadorBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("ColaboradorId", Data.ColaboradorId, System.Data.DbType.Int32);
            p.Add("AreaId", Data.AreaId, System.Data.DbType.Int32);
            await Set(p, Ekilibrate.BL.Queries.Administrador.QFacilitador.Insert);
        }

        public async Task Delete(clsFacilitadorBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("ColaboradorId", Data.ColaboradorId, System.Data.DbType.Int32);
             await Set(p, Ekilibrate.BL.Queries.Administrador.QFacilitador.Delete);
        }
    }
}
