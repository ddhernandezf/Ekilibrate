using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Participante;
using Ekilibrate.Model.Entity.Participante;

namespace Ekilibrate.ad.Participante
{
    public class clsParticipante : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsParticipanteBase, Int32>
    {
        public clsParticipante(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<clsParticipanteBase> GetById(int Id, int ProyectoId)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, System.Data.DbType.Int32);
            p.Add("ProyectoId", ProyectoId, System.Data.DbType.Int32);
            var r = await Get(p, QParticipante.GetById);
            return r.FirstOrDefault();
        }

        public async Task Insert(clsParticipanteBase Data)
        {
            var p = new DynamicParameters();
            p.Add("Id", Data.Id, System.Data.DbType.String);
            p.Add("PaisId", Data.PaisId, System.Data.DbType.String);
            p.Add("GrupoId", Data.GrupoId, System.Data.DbType.String);
            p.Add("Compa", Data.Compa, System.Data.DbType.String);
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.String);
            await Set(p, QParticipante.Insert);
        }

        public async Task Update(clsParticipanteBase Data)
        {
            var p = new DynamicParameters();
            p.Add("Id", Data.Id, System.Data.DbType.Int32);
            p.Add("PaisId", Data.PaisId, System.Data.DbType.Int32);
            p.Add("GrupoId", Data.GrupoId, System.Data.DbType.Int32);
            p.Add("Compa", Data.Compa, System.Data.DbType.Int32);
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            await Set(p, QParticipante.Update);
        }

        public async Task AsignarCompa(clsParticipanteBase Data)
        {
            var p = new DynamicParameters();
            p.Add("Id", Data.Id, System.Data.DbType.Int32);
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("Compa", Data.Compa, System.Data.DbType.String);
            await Set(p, QParticipante.Compa);
        }

        public async Task AsignarNutricionista(clsParticipanteBase Data)
        {
            var p = new DynamicParameters();
            p.Add("Id", Data.Id, System.Data.DbType.Int32);
            p.Add("NutricionistaId", Data.NutricionistaId, System.Data.DbType.String);
            await Set(p, QParticipante.Nutricionista);
        }

        public async Task AsignarCita(clsParticipanteBase Data)
        {
            var p = new DynamicParameters();
            p.Add("Id", Data.Id, System.Data.DbType.Int32);
            p.Add("CitaDia", Data.CitaDia, System.Data.DbType.Int32);
            p.Add("CitaHora", Data.CitaHora, System.Data.DbType.DateTime);
            p.Add("PrimeraCita", Data.PrimeraCita, System.Data.DbType.DateTime);
            await Set(p, QParticipante.Cita);
        }

        public async Task Delete(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, System.Data.DbType.Int32);
            await Set(p, QParticipante.Delete);
        }
    }
}
