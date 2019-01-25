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
    public class clsAlimentacionDia : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsAlimentacionDiaBase, Int32>
    {
        public clsAlimentacionDia(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }
        public async Task<Int32> Insert(clsAlimentacionDiaBase Data)
        {
            var p = ObtenerParametros(Data);
            return await SetWithResult<Int32>(p, QAlimentacionDia.Insert);
        }
        public async Task Update(IEnumerable<clsAlimentacionDiaBase> Data)
        {
            foreach (var i in Data)
            {
                var p = ObtenerParametros(i);
                await Set(p, QAlimentacionDia.Update);
            }
        }

        public async Task Update(clsAlimentacionDiaBase i)
        {
            var p = ObtenerParametros(i);
            await Set(p, QAlimentacionDia.Update);            
        }

        public DynamicParameters ObtenerParametros(clsAlimentacionDiaBase i)
        {
            var p = new DynamicParameters();
            p.Add("Id", i.Id, System.Data.DbType.Int32);
            p.Add("ParticipanteId", i.ParticipanteId, System.Data.DbType.Int32);
            p.Add("GrupoAlimentoId", i.GrupoAlimentoId, System.Data.DbType.Int32);
            p.Add("SemanaId", i.SemanaId, System.Data.DbType.Int32);
            p.Add("Dia", i.Dia, System.Data.DbType.Int32);
            p.Add("Meta", i.Meta, System.Data.DbType.Decimal);
            p.Add("Comido", i.Comido, System.Data.DbType.Decimal);

            return p;
        }

        public async Task Delete(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, System.Data.DbType.Int32);
            await Set(p, QAlimentacionDia.Delete);
        }
    }
}
