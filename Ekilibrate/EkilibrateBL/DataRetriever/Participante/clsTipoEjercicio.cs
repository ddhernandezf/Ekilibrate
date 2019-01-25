using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Participante;

namespace Ekilibrate.BL.DataRetriever.Participante
{
    public class clsTipoEjercicio : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Participante.clsTipoEjercicio, Int32>
    {
        private ILifetimeScope _lifetimeScope;
        public clsTipoEjercicio(ILifetimeScope lifetimeScope) : base(lifetimeScope) { _lifetimeScope = lifetimeScope; }


        public async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsTipoEjercicio>> GetTipoEjercicio()
        {
            var p = new DynamicParameters();
            return await Get(p, QActividadFisica.ListTipoEjercicio);
        }
    }
}
