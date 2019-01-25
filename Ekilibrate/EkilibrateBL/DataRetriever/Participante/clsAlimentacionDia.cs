using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Participante;
using Ekilibrate.Model.Entity.Participante;

namespace Ekilibrate.BL.DataRetriever.Participante
{
    public class clsAlimentacionDia : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Participante.clsAlimentacionDiaBase, Int32>
    {
        public clsAlimentacionDia(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsAlimentacionDiaBase>> GetAlimentacionDia(Ekilibrate.Model.Entity.Participante.clsAlimentacionDiaFiltro Filtro)
        {
            var p = new DynamicParameters();

            p.Add("ProyectoId", Filtro.ProyectoId, System.Data.DbType.Int32);
            p.Add("ParticipanteId", Filtro.ParticipanteId, System.Data.DbType.Int32);

            return await Get(p, QAlimentacionDia.List);
        }

        public async Task<Ekilibrate.Model.Entity.Participante.clsAlimentacionApp> GetAlimentacionDiaApp(Ekilibrate.Model.Entity.Participante.clsAlimentacionDiaFiltro Filtro)
        {
            var p = new DynamicParameters();
            p.Add("ParticipanteId", Filtro.ParticipanteId, System.Data.DbType.Int32);
            var ResPasos = await Get<Ekilibrate.Model.Entity.Participante.clsAlimentacionApp>(p, QAlimentacionDia.AlimentacionSemanaApp);

            if (ResPasos.Count() > 0)
            {
                var Result = ResPasos.First();
                var p2 = new DynamicParameters();
                p2.Add("ParticipanteId", Filtro.ParticipanteId, System.Data.DbType.Int32);
                var ResDia = await Get<Ekilibrate.Model.Entity.Participante.clsAlimentacionDiaApp>(p, QAlimentacionDia.AlimentacionDiaApp);

                Result.data = ResDia;
                return Result;
            }
            else
                throw new Exception("Error al buscar los pasos del participante.");
        }
    }
}
