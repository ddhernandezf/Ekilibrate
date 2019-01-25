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
    public class clsPreguntaLiderazgo : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Participante.clsPreguntaLiderazgo, Int32>
    {
        public clsPreguntaLiderazgo(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }
        public async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsPreguntaLiderazgo>> GetPreguntasLiderazgo(int Participante)
        {
            var p = new DynamicParameters();
            p.Add("ParticipanteId", Participante, System.Data.DbType.Int32);
            return await Get(p, QPreguntaLiderazgo.List);

        }

    }
}
