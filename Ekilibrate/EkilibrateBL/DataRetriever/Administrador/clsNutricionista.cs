using Autofac;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.DataRetriever.Administrador
{
    public class clsNutricionista : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Administrador.clsNutricionistaBase, Int32>
    {
        public clsNutricionista(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsNutricionistaBase>> GetNutricionista(Ekilibrate.Model.Entity.Administrador.clsNutricionistaFiltro Filtro)
        {
            var p = new DynamicParameters();

            if (Filtro.ProyectoId > 0) p.Add("ProyectoId", Filtro.ProyectoId, System.Data.DbType.Int32);

            //p.Add("Activity", Activity, System.Data.DbType.Int32);
            return await Get(p, Ekilibrate.BL.Queries.Administrador.QNutricionista.List);
        }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsNutricionistaBase>> GetNutricionista(int ProyectoId)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", ProyectoId, System.Data.DbType.Int32);
            return await Get(p, Ekilibrate.BL.Queries.Administrador.QNutricionista.List);
        }
    }
}
