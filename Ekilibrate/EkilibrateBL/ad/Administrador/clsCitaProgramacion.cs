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
    public class clsCitaProgramacion : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Administrador.clsCitaProgramacion, Int32>
    {
        public clsCitaProgramacion(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Ekilibrate.Model.Entity.Administrador.clsCitaProgramacion> GetOne(int CitaId)
        {
            var p = new DynamicParameters();
            p.Add("CitaId", CitaId, System.Data.DbType.Int32);
            var res = await Get(p, QCita.GetOne);
            return res.FirstOrDefault();
        }

        public async Task<Int32> Insert(Ekilibrate.Model.Entity.Administrador.clsCitaProgramacion Data)
        {
            var p = new DynamicParameters();
            p.Add("CitaId", Data.CitaId, System.Data.DbType.Int32);
            p.Add("NutricionistaId", Data.NutricionistaId, System.Data.DbType.Int32);
            p.Add("Fecha", Data.Fecha, System.Data.DbType.Date);
            p.Add("Cancelada", Data.Cancelada, System.Data.DbType.Boolean);
            p.Add("FechaInicio", Data.FechaInicio, System.Data.DbType.DateTime);
            p.Add("FechaFin", Data.FechaFin, System.Data.DbType.DateTime);
            return await SetWithResult<Int32>(p, QCitaProgramacion.Insert);
        }

        public async Task Update(Ekilibrate.Model.Entity.Administrador.clsCitaProgramacion Data)
        {
            var p = new DynamicParameters();
            p.Add("Id", Data.Id, System.Data.DbType.Int32);
            p.Add("CitaId", Data.CitaId, System.Data.DbType.Int32);
            p.Add("NutricionistaId", Data.NutricionistaId, System.Data.DbType.Int32);
            p.Add("Fecha", Data.Fecha, System.Data.DbType.Date);
            p.Add("Cancelada", Data.Cancelada, System.Data.DbType.Boolean);
            p.Add("FechaInicio", Data.FechaInicio, System.Data.DbType.DateTime);
            p.Add("FechaFin", Data.FechaFin, System.Data.DbType.DateTime);
            await Set(p, QCitaProgramacion.Update);
        }

        public async Task IniciarCita(int CitaId)
        {
            var p = new DynamicParameters();
            p.Add("CitaId", CitaId, System.Data.DbType.Int32);
            await Set(p, QCitaProgramacion.IniciarCita);
        }

        public async Task FinalizarCita(int CitaId)
        {
            var p = new DynamicParameters();
            p.Add("CitaId", CitaId, System.Data.DbType.Int32);
            await Set(p, QCitaProgramacion.FinalizarCita);
        }


        public async Task<Int32> InsertCancelado(Ekilibrate.Model.Entity.Administrador.clsCitaProgramacion Data)
        {
            var p = new DynamicParameters();
            p.Add("CitaId", Data.CitaId, System.Data.DbType.Int32);
            p.Add("NutricionistaId", Data.NutricionistaId, System.Data.DbType.Int32);
            p.Add("Fecha", Data.Fecha, System.Data.DbType.Date);
            p.Add("Cancelada", Data.Cancelada, System.Data.DbType.Boolean);
            p.Add("FechaInicio", Data.FechaInicio, System.Data.DbType.DateTime);
            p.Add("FechaFin", Data.FechaFin, System.Data.DbType.DateTime);
            return await SetWithResult<Int32>(p, QCitaProgramacion.InsertCancelado);
        }

        public async Task UpdateCancelado(Ekilibrate.Model.Entity.Administrador.clsCitaProgramacion Data)
        {
            var p = new DynamicParameters();
            p.Add("Id", Data.Id, System.Data.DbType.Int32);
            p.Add("CitaId", Data.CitaId, System.Data.DbType.Int32);
            p.Add("NutricionistaId", Data.NutricionistaId, System.Data.DbType.Int32);
            p.Add("Cancelada", Data.Cancelada, System.Data.DbType.Boolean);
            
            await Set(p, QCitaProgramacion.UpdateCancelado);
        }

        public async Task Delete(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, System.Data.DbType.Int32);
            await Set(p, QCitaProgramacion.Delete);
        }
    }
}
