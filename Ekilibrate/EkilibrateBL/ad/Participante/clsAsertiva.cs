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
    public class clsAsertiva : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Participante.clsAsertiva,Int32>
    {
        public clsAsertiva(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Insert(Ekilibrate.Model.Entity.Participante.clsAsertiva Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Data.ID_PARTICIPANTE, System.Data.DbType.Int32);
            p.Add("ID_PREGUNTA", Data.ID_PREGUNTA, System.Data.DbType.Int32);
            p.Add("EN_ABSOLUTO", Data.EN_ABSOLUTO, System.Data.DbType.Boolean);
            p.Add("UN_POCO", Data.UN_POCO, System.Data.DbType.Boolean);
            p.Add("BASTANTE", Data.BASTANTE, System.Data.DbType.Boolean);
            p.Add("MUCHO", Data.MUCHO, System.Data.DbType.Boolean);
            p.Add("MUCHISIMO", Data.MUCHISIMO, System.Data.DbType.Boolean);
            await Set(p, QAsertiva.insert);
        }
    }
}
