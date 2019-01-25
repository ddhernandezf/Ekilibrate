using Autofac;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.DataRetriever.Administrador
{
    public class clsGrupo : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Administrador.clsGrupoBase, Int32>
    {
        public clsGrupo(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsGrupoBase>> GetGrupo(Ekilibrate.Model.Entity.Administrador.clsGrupoFiltro Filtro)
        {
            var p = new DynamicParameters();

            if (Filtro.Id > 0) p.Add("Id", Filtro.Id, System.Data.DbType.Int32);
            if (Filtro.ProyectoId > 0) p.Add("ProyectoId", Filtro.ProyectoId, System.Data.DbType.Int32);
            if (Filtro.Nombre != null) p.Add("Nombre", Filtro.Nombre, System.Data.DbType.String); 

            //p.Add("Activity", Activity, System.Data.DbType.Int32);
            return await Get(p, Ekilibrate.BL.Queries.Administrador.QGrupo.List);
        }
    }
}
