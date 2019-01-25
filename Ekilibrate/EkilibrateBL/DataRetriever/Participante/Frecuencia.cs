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
    public class clsFrecuencia : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Participante.clsFrecuencia, Int32>
    {
        public clsFrecuencia(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }
        public async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsFrecuencia>> GetFrecuencias(Ekilibrate.Model.Entity.Participante.clsFrecuenciaFiltro Filtro)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Filtro.ID_PARTICIPANTE, System.Data.DbType.Int32);
            return await Get(p, QFrecuencia.List);

        }

    }
}
