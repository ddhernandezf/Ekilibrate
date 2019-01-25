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
    public class clsMedidaBebida : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Participante.clsMedidaBebida,Int32>
    {
        public clsMedidaBebida(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Insert(clsMedidaBebidaBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE",Data.ID_PARTICIPANTE,System.Data.DbType.Int32);
            p.Add("ID_MEDIDA", Data.ID_MEDIDA,System.Data.DbType.Int32);
            p.Add("RESPUESTA", Data.RESPUESTA, System.Data.DbType.Int32);
            await Set(p, QMedidaBebida.Insert);
        }

        public async Task Delete(clsMedidaBebidaBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Data.ID_PARTICIPANTE, System.Data.DbType.Int32);
            p.Add("ID_MEDIDA", Data.ID_MEDIDA, System.Data.DbType.Int32);
            await Set(p, QMedidaBebida.Delete);
        }
    }
}
