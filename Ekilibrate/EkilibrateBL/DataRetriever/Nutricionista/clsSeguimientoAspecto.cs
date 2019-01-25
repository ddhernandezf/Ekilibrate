using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Nutricionista;
using Ekilibrate.Model.Entity.Nutricionista;
using Ekilibrate.BL.ad.Nutricionista;

namespace Ekilibrate.BL.DataRetriever.Nutricionista
{
    public class clsSeguimientoAspectos : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Model.Entity.Nutricionista.clsSeguimientoAspectos, Int32>
    {
        public clsSeguimientoAspectos(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Model.Entity.Nutricionista.clsSeguimientoAspectos>> Get(int ParticipanteId, int CitaId)
        {
            var p = new DynamicParameters();
            p.Add("CitaId", CitaId, System.Data.DbType.Int32);
            p.Add("ParticipanteId", ParticipanteId, System.Data.DbType.Int32);
            var list = await Get(p, QSeguimientoAspectos.ListAspectos);
            list.ToList().ForEach(data =>
            {
                if (data.MetaAnterior != 0 && data.LogroAnterior != 0)                    
                    if (data.LogroAnterior == data.MetaAnterior || data.Base == data.MetaAnterior)
                        data.Porcentaje = 100;
                    else
                        //if (data.Aspecto.Equals("Agua"))
                        //    data.Porcentaje = Math.Round(((data.Base - data.MetaAnterior) / (data.Base - data.LogroAnterior)) * 100);
                        //else
                            data.Porcentaje = Math.Round(((data.Base - data.LogroAnterior) / (data.Base - data.MetaAnterior)) * 100);
                else
                    data.Porcentaje = 0;
            });
            return list;
        }
    }
}
