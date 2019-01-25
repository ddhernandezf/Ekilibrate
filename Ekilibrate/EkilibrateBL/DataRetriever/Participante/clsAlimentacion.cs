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
    public class clsAlimentacion : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Participante.clsAlimentacionBase,Int32>
    {
        public clsAlimentacion(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Ekilibrate.Model.Entity.Participante.clsAlimentacionBase> GetAlimentaciones(Ekilibrate.Model.Entity.Participante.clsAlimentacionFiltro Filtro)
        {
            var p = new DynamicParameters();
            if (Filtro.ID_PARTICIPANTE > 0) p.Add("ID_PARTICIPANTE", Filtro.ID_PARTICIPANTE, System.Data.DbType.Int32);
            IEnumerable<Ekilibrate.Model.Entity.Participante.clsAlimentacionBase> list = await Get(p, QAlimentacion.List);
            if (list.Count() > 0)
                return list.First<Ekilibrate.Model.Entity.Participante.clsAlimentacionBase>();
            else
                return null;
        }
    }
}
