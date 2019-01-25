using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Participante;
using Ekilibrate.Model.Entity.Participante;

namespace Ekilibrate.ad.Participante
{
    public class clsTestFinanzas : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Participante.clsTestFinanzas, List<Int32>>
    {
        public clsTestFinanzas(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Ekilibrate.Model.Entity.Participante.clsTestFinanzas> GetOne(int Participante, int Pregunta)
        {
            var p = new DynamicParameters();
            p.Add("ParticipanteId", Participante, System.Data.DbType.Int32);
            p.Add("PreguntaId", Pregunta, System.Data.DbType.Int32);
            var result = await Get(p, QTestFinanzas.GetOne);
            if (result != null && result.Count() > 0)
                return result.First();
            else
                return null;
        }

        public async Task Insert(Ekilibrate.Model.Entity.Participante.clsTestFinanzas Data)
        {
            var p = GetParams(Data);
            await Set(p, QTestFinanzas.Insert);
        }

        public async Task Update(Ekilibrate.Model.Entity.Participante.clsTestFinanzas Data)
        {
            var p = GetParams(Data);
            await Set(p, QTestFinanzas.Update);
        }

        private DynamicParameters GetParams(Ekilibrate.Model.Entity.Participante.clsTestFinanzas Data)
        {
            var p = new DynamicParameters();
            p.Add("ParticipanteId", Data.ParticipanteId, System.Data.DbType.Int32);
            p.Add("PreguntaId", Data.PreguntaId, System.Data.DbType.Int32);
            p.Add("RespuestaId", Data.RespuestaId, System.Data.DbType.Int32);
            return p;
        }
    }
}
