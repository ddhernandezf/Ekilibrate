using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Cliente;
using Ekilibrate.Model.Entity.Proyecto;

namespace Ekilibrate.BL.DataRetriever.Cliente
{
    public class clsProyecto : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Model.Entity.Proyecto.clsProyectoBase, Int32>
    {
        public clsProyecto(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Model.Entity.Proyecto.clsProyectoBase>> GetProyecto(clsProyectoFiltro Filtro)
        {
            var sFiltro = String.Empty;
            var p = new DynamicParameters();

            if (Filtro.Id > 0) p.Add("Id", Filtro.Id, System.Data.DbType.Int32);
            if (Filtro.EmpresaId > 0)
            {
                p.Add("EmpresaId", Filtro.EmpresaId, System.Data.DbType.Int32);
                sFiltro += " AND EmpresaId = @EmpresaId";
            }

            //p.Add("Activity", Activity, System.Data.DbType.Int32);
            return await Get(p, QProyecto.List + sFiltro);
        }

        public async Task<IEnumerable<Model.Entity.Proyecto.clsProyectoBase>> GetParticipantes(clsProyectoFiltro Filtro)
        {
            var p = new DynamicParameters();

            if (Filtro.Id > 0) p.Add("Id", Filtro.Id, System.Data.DbType.Int32);

            //p.Add("Activity", Activity, System.Data.DbType.Int32);
            return await Get(p, QProyecto.List);
        }
    }
}
