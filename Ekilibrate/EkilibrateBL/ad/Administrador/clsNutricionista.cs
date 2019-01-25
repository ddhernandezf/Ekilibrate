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
    public class clsNutricionista : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsNutricionistaBase, Int32>
    {
        public clsNutricionista(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Insert(clsNutricionistaBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("ColaboradorId", Data.ColaboradorId, System.Data.DbType.Int32);
            p.Add("Capacidad", Data.Capacidad, System.Data.DbType.Int32);
            p.Add("RolId", Data.RolId, System.Data.DbType.Int32);
            await Set(p, Ekilibrate.BL.Queries.Administrador.QNutricionista.Insert);
        }

        public async Task UpdateAsignados(clsNutricionistaBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("ColaboradorId", Data.ColaboradorId, System.Data.DbType.Int32);
            p.Add("Asignados", Data.Capacidad, System.Data.DbType.Int32);            
            await Set(p, Ekilibrate.BL.Queries.Administrador.QNutricionista.UpdateAsignados);
        }

        public async Task Delete(clsNutricionistaBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("ColaboradorId", Data.ColaboradorId, System.Data.DbType.Int32);
             await Set(p, Ekilibrate.BL.Queries.Administrador.QNutricionista.Delete);
        }
    }
}
