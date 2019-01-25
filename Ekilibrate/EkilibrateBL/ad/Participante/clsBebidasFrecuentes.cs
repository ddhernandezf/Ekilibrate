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
    public class clsBebidasFrecuentes : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Participante.clsBebidasFrecuentes, Int32>
    {
        public clsBebidasFrecuentes(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Ekilibrate.Model.Entity.Participante.clsBebidasFrecuentes> GetBebida(int Participante, int Bebida)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Participante, System.Data.DbType.Int32);
            p.Add("ID_BEBIDA", Bebida, System.Data.DbType.Int32);
            var r = await Get(p, QBebidasFrecuentes.GetOne);
            return r.FirstOrDefault();
        }
        
        public async Task Insert(clsBebidasFrecuentesBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Data.ID_PARTICIPANTE, System.Data.DbType.Int32);
            p.Add("ID_BEBIDA", Data.ID_BEBIDA, System.Data.DbType.Int32);
            p.Add("RESPUESTA", Data.RESPUESTA, System.Data.DbType.String);
             await Set(p, QBebidasFrecuentes.Insert);
        }

        public async Task Delete(clsBebidasFrecuentesBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Data.ID_PARTICIPANTE, System.Data.DbType.Int32);
            p.Add("ID_BEBIDA", Data.ID_BEBIDA, System.Data.DbType.Int32);
            await Set(p, QBebidasFrecuentes.Delete);
        }
    }
}
