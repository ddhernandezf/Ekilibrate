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
    public class clsExpediente : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Participante.clsExpedienteEstadoSalud, Int32>
    {
        private ILifetimeScope _lifetimeScope;

        public clsExpediente(ILifetimeScope lifetimeScope) : base(lifetimeScope) { _lifetimeScope = lifetimeScope; }

        public async Task<Ekilibrate.Model.Entity.Participante.clsExpedienteEstadoSalud> GetEstadoSalud(Ekilibrate.Model.Entity.Participante.clsExpedienteFiltro Filtro)
        {

            var p = new DynamicParameters();
            p.Add("IdParticipante", Filtro.ID_PARTICIPANTE, System.Data.DbType.Int32);
            var Res = await Get<Ekilibrate.Model.Entity.Participante.clsExpedienteEstadoSalud>(p, QExpediente.GetEstadoSalud);
            if (Res != null && Res.Count() > 0)
            {
                var result = Res.FirstOrDefault();
                result.FactoresRiesgo = new List<string>();
                result.CondicionesPrexistentes = new List<string>();
                if (result.Bebe) result.FactoresRiesgo.Add("Beber");
                if (result.Fuma) result.FactoresRiesgo.Add("Fumar");
                var enfermedades = await Get<string>(p, QExpediente.Efermedades);
                if (enfermedades != null && enfermedades.Count() > 0) result.FactoresRiesgo.AddRange(enfermedades);
                var preexistentes = await Get<string>(p, QExpediente.CondicionesPreexistentes);
                if (preexistentes != null && preexistentes.Count() > 0) result.CondicionesPrexistentes.AddRange(preexistentes);
                return result;
            }
            return new Model.Entity.Participante.clsExpedienteEstadoSalud();
        }

        public async Task<Ekilibrate.Model.Entity.Participante.clsExpedienteManejoEmociones> GetManejoEmociones(Ekilibrate.Model.Entity.Participante.clsExpedienteFiltro Filtro)
        {
            var p = new DynamicParameters();
            p.Add("IdParticipante", Filtro.ID_PARTICIPANTE, System.Data.DbType.Int32);
            var Res = await Get<Ekilibrate.Model.Entity.Participante.clsExpedienteManejoEmociones>(p, QExpediente.GetManejoEmociones);
            if (Res != null && Res.Count() > 0)
            {
                return Res.FirstOrDefault();
            }
            return new Model.Entity.Participante.clsExpedienteManejoEmociones();
        }

        public async Task<Ekilibrate.Model.Entity.Participante.clsExpedienteRelacionesInterpersonales> GetRelacionesInterpersonales(Ekilibrate.Model.Entity.Participante.clsExpedienteFiltro Filtro)
        {
            var p = new DynamicParameters();
            p.Add("IdParticipante", Filtro.ID_PARTICIPANTE, System.Data.DbType.Int32);
            var Res = await Get<Ekilibrate.Model.Entity.Participante.clsExpedienteRelacionesInterpersonales>(p, QExpediente.GetRelacionesInterpersonales);
            if (Res != null && Res.Count() > 0)
            {
                return Res.FirstOrDefault();
            }
            return new Model.Entity.Participante.clsExpedienteRelacionesInterpersonales();
        }

        public async Task<Ekilibrate.Model.Entity.Participante.clsExpedienteCrecimientoPersonal> GetCrecimientoPersonal(int Participante)
        {
            var p = new DynamicParameters();
            p.Add("IdParticipante", Participante, System.Data.DbType.Int32);
            var Res = await Get<Ekilibrate.Model.Entity.Participante.clsExpedienteCrecimientoPersonal>(p, QExpediente.GetCrecimientoPersonal);
            if (Res != null && Res.Count() > 0)
            {
                return Res.FirstOrDefault();
            }
            return new Model.Entity.Participante.clsExpedienteCrecimientoPersonal();
        }

        public async Task<Ekilibrate.Model.Entity.Participante.ResumenExpediente> GetResumenExpediente(int ParticipanteId)
        {
            var p = new DynamicParameters();
            p.Add("IdParticipante", ParticipanteId, System.Data.DbType.Int32);
            var Res = await Get<Ekilibrate.Model.Entity.Participante.ResumenExpediente>(p, QExpediente.GetResumen);
            if (Res != null && Res.Count() > 0)
            {
                return Res.FirstOrDefault();
            }
            return new Model.Entity.Participante.ResumenExpediente();
        }

    }
}
