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
    public class clsPasos : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsPasosBase, Int32>
    {
        public clsPasos(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<clsPasosBase> GetOne(int SemanaId, int ParticipanteId)
        {            
            var p = new DynamicParameters();
            p.Add("SemanaId", SemanaId, System.Data.DbType.Int32);
            p.Add("ParticipanteId", ParticipanteId, System.Data.DbType.Int32);

            var r = await Get(p, QPasos.GetOne);
            return r.FirstOrDefault();
        }

        public async Task<Int32> Insert(int SemanaId, int ParticipanteId)
        {
            var p = new DynamicParameters();
            p.Add("SemanaId", SemanaId, System.Data.DbType.Int32);
            p.Add("ParticipanteId", ParticipanteId, System.Data.DbType.Int32);
            
            return await SetWithResult<Int32>(p, QPasos.Insert);
        }

        public async Task Update(int SemanaId, int ParticipanteId)
        {
            var p = new DynamicParameters();
            p.Add("SemanaId", SemanaId, System.Data.DbType.Int32);
            p.Add("ParticipanteId", ParticipanteId, System.Data.DbType.Int32);

            await Set(p, QPasos.Update);            
        }        
    }
}
