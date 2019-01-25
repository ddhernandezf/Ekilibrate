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
    public class clsFrecuencia: Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Participante.clsFrecuencia, Int32>
    {
        public clsFrecuencia(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Insert(Ekilibrate.Model.Entity.Participante.clsFrecuencia Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Data.ID_PARTICIPANTE, System.Data.DbType.Int32);
            p.Add("ID_PREGUNTA", Data.ID_PREGUNTA, System.Data.DbType.Int32);
            p.Add("SIEMPRE", Data.SIEMPRE, System.Data.DbType.Boolean);
            p.Add("FRECUENTE", Data.FRECUENTE, System.Data.DbType.Boolean);
            p.Add("CASI_NUNCA", Data.CASI_NUNCA, System.Data.DbType.Boolean);
            p.Add("NUNCA", Data.NUNCA, System.Data.DbType.Boolean);
            await Set(p, QFrecuencia.insert);
        }

        
    }
}
