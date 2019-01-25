using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Administrador;
using Ekilibrate.Model.Entity.Administrador;

namespace Ekilibrate.ad.Administrador
{
    public class clsCita : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Administrador.clsCita, Int32>
    {
        public clsCita(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Ekilibrate.Model.Entity.Administrador.clsCita> GetOne(int CitaId)
        {
            var p = new DynamicParameters();
            p.Add("CitaId", CitaId, System.Data.DbType.Int32);
            var res = await Get(p, QCita.GetOne);
            return res.FirstOrDefault();
        }

        public async Task<Int32> Insert(Ekilibrate.Model.Entity.Administrador.clsCita Data)
        {
            var p = new DynamicParameters();
            p.Add("CicloId", Data.CicloId, System.Data.DbType.Int32);
            p.Add("ParticipanteId", Data.ParticipanteId, System.Data.DbType.Int32);
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("FechaProgramada", Data.FechaProgramada, System.Data.DbType.Date);
            p.Add("NotaGlobal", Data.NotaGlobal, System.Data.DbType.Decimal);
            p.Add("Ranking", Data.Ranking, System.Data.DbType.Int32);
            p.Add("TipoCitaId", Data.TipoCitaId, System.Data.DbType.Int32);
            return await SetWithResult<Int32>(p, QCita.Insert);
        }

        public async Task Update(Ekilibrate.Model.Entity.Administrador.clsCita Data)
        {
            var p = new DynamicParameters();
            p.Add("Id", Data.Id, System.Data.DbType.Int32);
            p.Add("CicloId", Data.CicloId, System.Data.DbType.Int32);
            p.Add("ParticipanteId", Data.ParticipanteId, System.Data.DbType.Int32);
            p.Add("FechaProgramada", Data.FechaProgramada, System.Data.DbType.Date);
            p.Add("NotaGlobal", Data.NotaGlobal, System.Data.DbType.Decimal);
            p.Add("Ranking", Data.Ranking, System.Data.DbType.Int32);
            p.Add("TipoCitaId", Data.TipoCitaId, System.Data.DbType.Int32);
            await Set(p, QCita.Update);
        }

        public async Task Delete(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, System.Data.DbType.Int32);
            await Set(p, QCita.Delete);
        }
    }
}
