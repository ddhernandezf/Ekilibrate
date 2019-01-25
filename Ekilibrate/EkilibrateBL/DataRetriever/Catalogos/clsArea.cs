using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries;

namespace Ekilibrate.BL.DataRetriever
{
    public class clsArea : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Catalogos.clsAreaBase, Int32>
    {
        public clsArea(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Catalogos.clsAreaBase>> GetArea(Ekilibrate.Model.Entity.Catalogos.clsAreaFiltro Filtro)
        {
            var p = new DynamicParameters();
            if (Filtro.ProyectoId > 0)
            {
                p.Add("ProyectoId", Filtro.ProyectoId, System.Data.DbType.Int32);
                return await Get(p, Ekilibrate.BL.Queries.Catalogos.QArea.ListPorProyecto);
            }
            return await Get(p, Ekilibrate.BL.Queries.Catalogos.QArea.List);
        }
    }
}
