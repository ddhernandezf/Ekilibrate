using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries;

namespace Ekilibrate.BL.DataRetriever.Catalogos
{
    public class clsTipoProyecto : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Catalogos.clsTipoProyecto, Int32>
    {
        public clsTipoProyecto(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Catalogos.clsTipoProyecto>> GetTipoProyecto()
        {
            var p = new DynamicParameters();
            return await Get(p, Ekilibrate.BL.Queries.Catalogos.QTipoProyecto.List);
        }
    }
}
