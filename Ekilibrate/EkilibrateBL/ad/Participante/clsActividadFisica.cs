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
    public class clsActividadFisica : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Participante.clsActividadFisica, Int32>
    {
        public clsActividadFisica(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Ekilibrate.Model.Entity.Participante.clsActividadFisica> GetByParticipante(int ID_PARTICIPANTE)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", ID_PARTICIPANTE, System.Data.DbType.Int32);
            var result = await Get(p, QActividadFisica.List);
            if (result != null && result.Count() > 0)
                return result.First();
            else
                return new Model.Entity.Participante.clsActividadFisica();
        }
                
        public async Task Insert(Ekilibrate.Model.Entity.Participante.clsActividadFisica Data)
        {
            var p = GetParams(Data);
            await Set(p, QActividadFisica.Insert);
        }

        public async Task Update(Ekilibrate.Model.Entity.Participante.clsActividadFisica Data)
        {
            var p = GetParams(Data);
            await Set(p, QActividadFisica.Update);
        }

        public async Task Delete(int ID_PARTICIPANTE)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", ID_PARTICIPANTE, System.Data.DbType.Int32);
            await Set(p, QActividadFisica.Delete);
        }

        private DynamicParameters GetParams(Ekilibrate.Model.Entity.Participante.clsActividadFisica Data)
        {
            var p = new DynamicParameters();
            p.Add("REALIZA_ACTIVIDAD", Data.REALIZA_ACTIVIDAD, System.Data.DbType.Boolean);
            p.Add("ID_PRINCIPAL", Data.ID_PRINCIPAL, System.Data.DbType.Int32);
            p.Add("PRINCIPAL_VECES", Data.PRINCIPAL_VECES, System.Data.DbType.Int32);
            p.Add("PRINCIPAL_TIEMPO", Data.PRINCIPAL_TIEMPO, System.Data.DbType.Int32);
            p.Add("ID_SECUNDARIO", Data.ID_SECUNDARIO, System.Data.DbType.Int32);
            p.Add("SECUNDARIO_VECES", Data.SECUNDARIO_VECES, System.Data.DbType.Int32);
            p.Add("SECUNDARIO_TIEMPO", Data.SECUNDARIO_TIEMPO, System.Data.DbType.Int32);
            p.Add("ID_PARTICIPANTE", Data.ID_PARTICIPANTE, System.Data.DbType.Int32);
            return p;
        }
    }
}
