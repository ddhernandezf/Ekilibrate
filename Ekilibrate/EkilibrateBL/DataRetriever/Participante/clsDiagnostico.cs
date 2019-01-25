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
    public class clsDiagnostico : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Participante.clsDiagnosticoBase, Int32>
    {
        public clsDiagnostico(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Ekilibrate.Model.Entity.Participante.clsDiagnosticoBase> GetDiagnosticos(Ekilibrate.Model.Entity.Participante.clsDiagnosticoFiltro Filtro)
        {
            var p = new DynamicParameters();
            if (Filtro.ID_PARTICIPANTE > 0) p.Add("ID_PARTICIPANTE", Filtro.ID_PARTICIPANTE, System.Data.DbType.Int32);
            IEnumerable<Ekilibrate.Model.Entity.Participante.clsDiagnosticoBase> list = await Get(p, QDiagnostico.List);
            //if (string.IsNullOrEmpty(list.First<Ekilibrate.Model.Entity.Participante.clsDiagnosticoBase>().FACEBOOK)) list.First<Ekilibrate.Model.Entity.Participante.clsDiagnosticoBase>().FACEBOOK = "facebook.com/";
            return list.First<Ekilibrate.Model.Entity.Participante.clsDiagnosticoBase>();
        }
    }
}
