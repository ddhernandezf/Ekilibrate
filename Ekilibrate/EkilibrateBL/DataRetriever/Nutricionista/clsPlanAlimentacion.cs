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
    public class claPlanAlimentacion : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Model.Entity.Nutricionista.clsPlanAlimentacion, Int32>
    {
        public claPlanAlimentacion(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Model.Entity.Nutricionista.clsPlanAlimentacion> Get(int CitaId, int ParticipanteId)
        {
            var p = new DynamicParameters();
            p.Add("CitaId", CitaId, System.Data.DbType.Int32);
            p.Add("ParticipanteId", ParticipanteId, System.Data.DbType.Int32);
            //p.Add("Activity", Activity, System.Data.DbType.Int32);
            var result = await Get(p, QPlanAlimentacion.Get);
            return result.FirstOrDefault();
        }

    }
}
