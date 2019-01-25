using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Nutricionista;
using Ekilibrate.Model.Entity.Nutricionista;
using Ekilibrate.BL.ad.Nutricionista;

namespace Ekilibrate.BL.DataRetriever.Nutricionista
{
    public class clsMetaPasos : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Model.Entity.Nutricionista.clsMetaPasoBase, Int32>
    {
        public clsMetaPasos(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Model.Entity.Nutricionista.clsMetaPasoBase>> Get(int ParticipanteId) 
        {
            var p = new DynamicParameters();
            
            p.Add("ParticipanteId", ParticipanteId, System.Data.DbType.Int32);
            //p.Add("Activity", Activity, System.Data.DbType.Int32);
            var result = await Get(p, QMetaPasos.List);
            return result;

        }

    }
}
