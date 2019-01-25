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
    public class clsPasosDia : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsPasosDiaBase, Int32>
    {
        public clsPasosDia(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<clsPasosDiaBase> GetOne(int SemanaId, int ParticipanteId, int Dia)
        {            
            var p = new DynamicParameters();
            p.Add("SemanaId", SemanaId, System.Data.DbType.Int32);
            p.Add("ParticipanteId", ParticipanteId, System.Data.DbType.Int32);
            p.Add("Dia", Dia, System.Data.DbType.Int32);

            var r = await Get(p, QPasosDia.GetOne);
            return r.FirstOrDefault();
        }

        public async Task<Int32> Insert(clsPasosDiaBase Data)
        {
            var p = new DynamicParameters();
            p.Add("Id", Data.Id, System.Data.DbType.Int32);
            p.Add("SemanaId", Data.SemanaId, System.Data.DbType.Int32);
            p.Add("ParticipanteId", Data.ParticipanteId, System.Data.DbType.Int32);
            p.Add("Dia", Data.Dia, System.Data.DbType.Int32);
            p.Add("Meta", Data.Meta, System.Data.DbType.Int32);
            p.Add("Caminados", Data.Caminados, System.Data.DbType.Int32);
            //p.Add("FechaRegistro", Data.FechaRegistro, System.Data.DbType.DateTime);
            
            return await SetWithResult<Int32>(p, QPasosDia.Insert);
        }

        public async Task Update(IEnumerable<clsPasosDiaBase> Data)
        {
            foreach (var i in Data)
            {
                var p = new DynamicParameters();
                p.Add("Id", i.Id, System.Data.DbType.Int32);
                p.Add("Caminados", i.Caminados, System.Data.DbType.Int32);

                await Set(p, QPasosDia.Update);
            }
        }

        public async Task Update(clsPasosDiaBase Data)
        {
            var p = new DynamicParameters();
            p.Add("Id", Data.Id, System.Data.DbType.Int32);
            p.Add("Caminados", Data.Caminados, System.Data.DbType.Int32);

            await Set(p, QPasosDia.Update);
            
        }
        public async Task Delete(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, System.Data.DbType.Int32);
            await Set(p, QPasosDia.Delete);
        }
    }
}
