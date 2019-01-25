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
    public class clsPasosDia : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Participante.clsPasosDiaBase, Int32>
    {
        public clsPasosDia(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsRegistroPasos>> GetPasosDia(int Participante)
        {
            var p = new DynamicParameters();
            p.Add("ParticipanteId", Participante, System.Data.DbType.Int32);
            return await Get<clsRegistroPasos>(p, QPasosDia.List);
        }

        public async Task<Ekilibrate.Model.Entity.Participante.clsPasosDiaBase> GetPasosDia(int ParticipanteId, DateTime Fecha)
        {
            var p = new DynamicParameters();
            p.Add("ParticipanteId", ParticipanteId, System.Data.DbType.Int32);
            p.Add("Fecha", Fecha, System.Data.DbType.DateTime);
            var ResPasos = await Get(p, QPasosDia.PasosDia);
            if (ResPasos.Count() > 0)
                return ResPasos.First();
            else
                return null;
        }

        public async Task<Ekilibrate.Model.Entity.Participante.clsPasosApp> GetPasosDiaApp(int ParticipanteId)
        {
            var p = new DynamicParameters();
            p.Add("ParticipanteId", ParticipanteId, System.Data.DbType.Int32);
            var ResPasos = await Get<Ekilibrate.Model.Entity.Participante.clsPasosApp>(p, QPasosDia.PasosSemanaApp);

            if (ResPasos.Count() > 0)
            {
                var Result = ResPasos.FirstOrDefault();
                var p2 = new DynamicParameters();
                p2.Add("ParticipanteId", Result.CompaId, System.Data.DbType.Int32);
                var ResPasosDia = await Get<Ekilibrate.Model.Entity.Participante.clsPasosDiaApp>(p, QPasosDia.PasosDiaApp);

                Result.data = ResPasosDia;
                return Result;
            }
            else
                throw new Exception("No se encontraron datos pasos del participante.");
        }
    }
}
