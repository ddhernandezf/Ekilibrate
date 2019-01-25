using Autofac;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.DataRetriever.Administrador
{
    public class clsFacilitador : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Administrador.clsFacilitador, Int32>
    {
        public clsFacilitador(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsFacilitador>> GetFacilitador(Ekilibrate.Model.Entity.Administrador.clsFacilitadorFiltro Filtro)
        {
            var p = new DynamicParameters();

            if (Filtro.ProyectoId > 0) p.Add("ProyectoId", Filtro.ProyectoId, System.Data.DbType.Int32);


            return await Get(p, Ekilibrate.BL.Queries.Administrador.QFacilitador.List);
        }
    }
}
