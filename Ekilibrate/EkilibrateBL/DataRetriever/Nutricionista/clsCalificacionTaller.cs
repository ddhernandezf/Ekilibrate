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
    public class clsCalificacionTaller : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Model.Entity.Nutricionista.clsCalificacionTaller, Int32>
    {
        public clsCalificacionTaller(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Model.Entity.Nutricionista.clsCalificacionTaller>> Get(int ParticipanteId, int TallerId) 
        {
            var p = new DynamicParameters();
            
            p.Add("ParticipanteId", ParticipanteId, System.Data.DbType.Int32);
            p.Add("TallerId", TallerId, System.Data.DbType.Int32);
            //p.Add("Activity", Activity, System.Data.DbType.Int32);
            var result = await Get(p,QCalificacionTaller.List);
            return result;

        }

    }
}
