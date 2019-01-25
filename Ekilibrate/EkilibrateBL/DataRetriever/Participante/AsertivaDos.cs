using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Participante;


namespace Ekilibrate.BL.DataRetriever.Participante
{
    public class clsAsertivaDos : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Participante.clsAsertivaDos, Int32>
    {
        public clsAsertivaDos(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }
        public async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsAsertivaDos>> GetAsertivasDos(Ekilibrate.Model.Entity.Participante.clsAsertivaDosFiltro Filtro)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Filtro.ID_PARTICIPANTE, System.Data.DbType.Int32);
            return await Get(p, QAsertivaDos.List);

        }

    }
}
