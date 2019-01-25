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
    public class clsParticipante : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Model.Entity.Participante.clsParticipante, Int32>
    {
        public clsParticipante(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Model.Entity.Participante.clsParticipante>> GetParticipantes(clsParticipanteFiltro Filtro)
        {
            var p = new DynamicParameters();

            if (Filtro.ProyectoId > 0) p.Add("ProyectoId", Filtro.ProyectoId, System.Data.DbType.Int32);
            if (Filtro.GrupoId > 0) p.Add("GrupoId", Filtro.GrupoId, System.Data.DbType.Int32);

            //p.Add("Activity", Activity, System.Data.DbType.Int32);
            return await Get(p, QParticipante.List);
        }

        public async Task<IEnumerable<Model.Entity.Participante.clsParticipante>> GetParticipantes(int ProyectoId)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", ProyectoId, System.Data.DbType.Int32);
            return await Get(p, QParticipante.List);
        }

        public async Task<IEnumerable<Model.Entity.Participante.clsParticipante>> GetParticipantesTest(int ProyectoId)
        {
            var p = new DynamicParameters();
            return await Get(p, QParticipante.ListTest);
        }

        public async Task<IEnumerable<Model.Entity.Participante.clsParticipante>> GetParticipantesSinCitas(int ProyectoId)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", ProyectoId, System.Data.DbType.Int32);
            return await Get(p, QParticipante.ListSinCitas);
        }

        public async Task<IEnumerable<Model.Entity.Participante.clsAvanceCuestionario>> GetParticipantesRecordatorio(int ProyectoId)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", ProyectoId, System.Data.DbType.Int32);
            return await Get<Model.Entity.Participante.clsAvanceCuestionario>(p, QParticipante.ListRecordatorio);
        }

        public async Task<IEnumerable<Model.Entity.Participante.clsParticipante>> GetParticipantesRecordatorioCita(int ProyectoId)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", ProyectoId, System.Data.DbType.Int32);

            string Filter = string.Empty;

            switch(DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    Filter = "1";
                    break;
                case DayOfWeek.Monday:
                    Filter = "2, 3";
                    break;
                case DayOfWeek.Tuesday:
                    Filter = "4, 5";
                    break;
                case DayOfWeek.Wednesday:
                    Filter = "3, 4";
                    break;
            }

            string Query = string.Format(QParticipante.ListRecordatorioCita, Filter);

            return await Get<Model.Entity.Participante.clsParticipante>(p, Query);
        }

        public async Task<IEnumerable<Model.Entity.Participante.clsAvanceCuestionario>> GetParticipantesAvance(int ProyectoId)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", ProyectoId, System.Data.DbType.Int32);
            return await Get<Model.Entity.Participante.clsAvanceCuestionario>(p, QParticipante.ListAvance);
        }

        public async Task<Model.Entity.Participante.clsAvanceCuestionario> GetParticipanteAvance(int ParticipanteId)
        {
            var p = new DynamicParameters();
            p.Add("ParticipanteId", ParticipanteId, System.Data.DbType.Int32);
            
            var r = await Get<Model.Entity.Participante.clsAvanceCuestionario>(p, QParticipante.GetAvance);
            return r.FirstOrDefault();
        }

        public async Task<Model.Entity.Participante.clsParticipante> GetCompa(int ParticipanteId)
        {
            var p = new DynamicParameters();
            p.Add("Compa", ParticipanteId, System.Data.DbType.Int32);
            var result = await Get(p, QParticipante.GetCompa);
            return result.FirstOrDefault();
        }

        public async Task<IEnumerable<Model.Entity.Participante.clsParticipante>> GetParticipantesPorGrupo(int GrupoId)
        {
            var p = new DynamicParameters();
            p.Add("GrupoId", GrupoId, System.Data.DbType.Int32);
            return await Get(p, QParticipante.ListPorGrupo);
        }
    }
}
