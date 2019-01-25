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
    public class clsRolNutricionista : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Catalogos.clsRolNutricionista, Int32>
    {
        public clsRolNutricionista(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Catalogos.clsRolNutricionista>> GetRolNutricionista()
        {
            var p = new DynamicParameters();
            return await Get(p, Ekilibrate.BL.Queries.Catalogos.QRolNutricionista.List);
        }
    }
}
