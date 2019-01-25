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
    public class clsAnamnesis : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Model.Entity.Nutricionista.DiagnosticoAnamnesisTiempo, Int32>
    {
        public clsAnamnesis(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Model.Entity.Nutricionista.DiagnosticoAnamnesisTiempo>> GetAnamnesis(int NutricionistaId, int ParticipanteId, int CitaId)
        {
            var p = new DynamicParameters();
            p.Add("NutricionistaId", NutricionistaId, System.Data.DbType.Int32);
            p.Add("ParticipanteId", ParticipanteId, System.Data.DbType.Int32);
            p.Add("CitaId", CitaId, System.Data.DbType.Int32);
            //p.Add("Activity", Activity, System.Data.DbType.Int32);
            return await Get(p, QAnamnesis.PrimeraAnamnesis);
        }


    }
}
