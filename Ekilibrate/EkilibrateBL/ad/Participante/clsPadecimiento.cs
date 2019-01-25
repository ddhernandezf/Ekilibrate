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
    public class clsPadecimiento : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Participante.clsPadecimiento, Int32>
    {
        public clsPadecimiento(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Ekilibrate.Model.Entity.Participante.clsPadecimiento> GetByParticipante(int Participante)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Participante, System.Data.DbType.Int32);
            var result = await Get(p, QPadecimiento.List);
            if (result != null && result.Count() > 0)
            {
                result.First().TRATAMIENTO = result.First().PADECIMIENTO_PRINCIPAL != null && result.First().PADECIMIENTO_PRINCIPAL.Length > 0;
                return result.First();
            }
            else
                return new Model.Entity.Participante.clsPadecimiento();
        }

        public async Task<Int32> Insert(Ekilibrate.Model.Entity.Participante.clsPadecimiento Data)
        {
            var p = GetParams(Data);
            return await SetWithResult<Int32>(p, QPadecimiento.Insert);
        }

        public async Task Update(Ekilibrate.Model.Entity.Participante.clsPadecimiento Data)
        {
            var p = GetParams(Data);
            await SetWithResult<Int32>(p, QPadecimiento.Update);
        }

        public async Task Delete(int ID_PARTICIPANTE)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", ID_PARTICIPANTE, System.Data.DbType.Int32);
            await Set(p, QPadecimiento.Delete);
        }

        private DynamicParameters GetParams(Ekilibrate.Model.Entity.Participante.clsPadecimiento Data)
        {
            var p = new DynamicParameters();
            p.Add("PADECIMIENTO_PRINCIPAL", Data.PADECIMIENTO_PRINCIPAL, System.Data.DbType.String);
            p.Add("PADECIMIENTO_SECUNDARIO", Data.PADECIMIENTO_SECUNDARIO, System.Data.DbType.String);
            p.Add("MEDICAMENTO_PRINCIPAL", Data.MEDICAMENTO_PRINCIPAL, System.Data.DbType.String);
            p.Add("MEDICAMENTO_SECUNDARIO", Data.MEDICAMENTO_SECUNDARIO, System.Data.DbType.String);
            p.Add("ID_PARTICIPANTE", Data.ID_PARTICIPANTE, System.Data.DbType.Int32);
            return p;
        }
    }
}
