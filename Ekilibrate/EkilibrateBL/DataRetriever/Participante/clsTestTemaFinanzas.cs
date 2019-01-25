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
    public class clsTestTemaFinanzas : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Participante.clsTestTemaFinanzas, List<Int32>>
    {
        public clsTestTemaFinanzas(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }
        
        public async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsTestTemaFinanzas>> GetPreguntas(int Participante)
        {
            var p = new DynamicParameters();
            p.Add("ParticipanteId", Participante, System.Data.DbType.Int32);
            return await Get(p, QTemaFinanzas.Preguntas);
        }
    }
}
