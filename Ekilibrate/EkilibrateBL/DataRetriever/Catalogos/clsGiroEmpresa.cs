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
    public class clsGiroEmpresa : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Catalogos.clsGiroEmpresaBase, Int32>
    {
        public clsGiroEmpresa(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Catalogos.clsGiroEmpresaBase>> GetGiroEmpresa()
        {
            var p = new DynamicParameters();
            return await Get(p, Ekilibrate.BL.Queries.Catalogos.QGiroEmpresa.List);
        }
    }
}
