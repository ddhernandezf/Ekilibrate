using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Participante;
using Ekilibrate.Model.Entity.Participante;

namespace Ekilibrate.BL.ad.Participante
{
    public class clsTestLiderazgo : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Participante.clsTestLiderazgoBase, List<Int32>>
    {
        public clsTestLiderazgo(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Ekilibrate.Model.Entity.Participante.clsTestLiderazgoBase> GetOne(int Participante, int Pregunta)
        {
            var p = new DynamicParameters();
            p.Add("ParticipanteId", Participante, System.Data.DbType.Int32);
            p.Add("PreguntaId", Pregunta, System.Data.DbType.Int32);
            var result = await Get(p, QTestLiderazgo.GetOne);
            if (result != null && result.Count() > 0)
                return result.First();
            else
                return null;
        }

        public async Task<Int32> Insert(Ekilibrate.Model.Entity.Participante.clsTestLiderazgoBase Data)
        {
            var p = GetParams(Data);
            
            return await SetWithResult<Int32>(p, QTestLiderazgo.Insert);
        }
        public async Task Update(clsTestLiderazgoBase Data)
        {
            var p = GetParams(Data);
            await SetWithResult<Int32>(p, QTestLiderazgo.Update);
        }

        private DynamicParameters GetParams(clsTestLiderazgoBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ParticipanteId", Data.ParticipanteId, System.Data.DbType.Int32);
            p.Add("PreguntaId", Data.PreguntaId, System.Data.DbType.Int32);
            p.Add("Siempre", Data.Siempre, System.Data.DbType.Boolean);
            p.Add("Frecuentemente", Data.Frecuentemente, System.Data.DbType.Boolean);
            p.Add("CasiNunca", Data.CasiNunca, System.Data.DbType.Boolean);
            p.Add("Nunca", Data.Nunca, System.Data.DbType.Boolean);

            return p;
        }
    }
}
