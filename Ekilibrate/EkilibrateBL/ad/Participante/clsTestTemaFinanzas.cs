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
    public class clsTestTemaFinanzas : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Participante.clsTestTemaFinanzas, List<Int32>>
    {
        public clsTestTemaFinanzas(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Ekilibrate.Model.Entity.Participante.clsTestTemaFinanzas> GetOne(int Participante, int Tema)
        {
            var p = new DynamicParameters();
            p.Add("ParticipanteId", Participante, System.Data.DbType.Int32);
            p.Add("TemaId", Tema, System.Data.DbType.Int32);
            var result = await Get(p, QTemaFinanzas.GetOne);
            if (result != null && result.Count() > 0)
                return result.First();
            else
                return null;
        }

        public async Task Insert(Ekilibrate.Model.Entity.Participante.clsTestTemaFinanzas Data)
        {
            var p = GetParams(Data);
            await Set(p, QTemaFinanzas.Insert);
        }

        public async Task Delete(Ekilibrate.Model.Entity.Participante.clsTestTemaFinanzas Data)
        {
            var p = GetParams(Data);
            await Set(p, QTemaFinanzas.Delete);
        }

        private DynamicParameters GetParams(Ekilibrate.Model.Entity.Participante.clsTestTemaFinanzas Data)
        {
            var p = new DynamicParameters();
            p.Add("ParticipanteId", Data.ParticipanteId, System.Data.DbType.Int32);
            p.Add("TemaId", Data.TemaId, System.Data.DbType.Int32);
            return p;
        }
    }
}
