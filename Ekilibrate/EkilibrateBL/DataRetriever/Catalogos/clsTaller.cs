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
    public class clsTaller : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Catalogos.clsTallerBase, Int32>
    {
        public clsTaller(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Catalogos.clsTallerBase>> GetTallerCatalogo(Ekilibrate.Model.Entity.Catalogos.clsTallerFiltro Filtro)
        {
            var p = new DynamicParameters();

            if (Filtro.ProyectoId != null)
            {
                p.Add("ProyectoId", Filtro.ProyectoId, System.Data.DbType.Int32);
                return await Get(p, Ekilibrate.BL.Queries.Catalogos.QTaller.ListTalleresProyecto);
            }
            else
            {
                return await Get(p, Ekilibrate.BL.Queries.Catalogos.QTaller.List);
            }
        }
    }
}
