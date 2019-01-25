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
    public class clsTestFinanzas : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Participante.clsPreguntaFinanzasBase, Int32>
    {
        public clsTestFinanzas(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }
        public async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsPreguntaFinanzas>> GetPreguntas(int Participante)
        {

            var p = new DynamicParameters();
            var Res = await Get<Ekilibrate.Model.Entity.Participante.clsPreguntaFinanzas>(p, QTestFinanzas.Preguntas);

            foreach (var item in Res)
            {
                var par = new DynamicParameters();
                par.Add("PreguntaId", item.Id, System.Data.DbType.Int32);
                par.Add("ParticipanteId", Participante, System.Data.DbType.Int32);
                var detalle = await Get<Ekilibrate.Model.Entity.Participante.clsRespuestaFinanzas>(par, QTestFinanzas.Respuestas);

                item.Detalle = detalle;
            }

            return Res;
        }

    }
}
