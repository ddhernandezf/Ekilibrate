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
    public class clsAsertiva : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Participante.clsAsertiva, Int32>
    {
        public clsAsertiva(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }
        public async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsAsertiva>> GetAsertivas(Ekilibrate.Model.Entity.Participante.clsAsertivaFiltro Filtro)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Filtro.ID_PARTICIPANTE, System.Data.DbType.Int32);
            return await Get(p, QAsertiva.List);

        }

    }
}
