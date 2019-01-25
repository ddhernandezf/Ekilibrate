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
    public class clsEnfermera : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsEnfermeraBase, Int32>
    {
        public clsEnfermera(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Insert(clsEnfermeraBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("ColaboradorId", Data.ColaboradorId, System.Data.DbType.Int32);            
            await Set(p, Ekilibrate.BL.Queries.Administrador.QEnfermera.Insert);
        }


        public async Task Delete(clsEnfermeraBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("ColaboradorId", Data.ColaboradorId, System.Data.DbType.Int32);
            await Set(p, Ekilibrate.BL.Queries.Administrador.QEnfermera.Delete);
        }
    }
}
