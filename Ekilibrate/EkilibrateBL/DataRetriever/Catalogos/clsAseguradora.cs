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
    public class clsAseguradora : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Catalogos.clsAseguradoraBase, Int32>
    {
        public clsAseguradora(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Catalogos.clsAseguradoraBase>> GetAseguradoraCatalogo()
        {
            var p = new DynamicParameters();

            return await Get(p, Ekilibrate.BL.Queries.Catalogos.QAseguradora.List);
        }
    }
}
