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
    public class clsAsertivaDos : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Participante.clsAsertivaDos, Int32>
    {
        public clsAsertivaDos(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Insert(Ekilibrate.Model.Entity.Participante.clsAsertivaDos Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Data.ID_PARTICIPANTE, System.Data.DbType.Int32);
            p.Add("ID_PREGUNTA", Data.ID_PREGUNTA, System.Data.DbType.Int32);
            p.Add("SIEMPRE_LO_HAGO", Data.SIEMPRE_LO_HAGO, System.Data.DbType.Boolean);
            p.Add("HABITUALMENTEBIT", Data.HABITUALMENTEBIT, System.Data.DbType.Boolean);
            p.Add("MITAD_VECES", Data.MITAD_VECES, System.Data.DbType.Boolean);
            p.Add("RARAMENTE", Data.RARAMENTE, System.Data.DbType.Boolean);
            p.Add("NUNCA", Data.NUNCA, System.Data.DbType.Boolean);
            await Set(p, QAsertivaDos.insert);
        }
    }
}
