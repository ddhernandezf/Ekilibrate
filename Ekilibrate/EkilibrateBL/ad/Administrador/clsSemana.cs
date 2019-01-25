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
    public class clsSemana : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Administrador.clsSemana, Int32>
    {
        public clsSemana(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Insert(Ekilibrate.Model.Entity.Administrador.clsSemana Data)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("Semana", Data.Semana, System.Data.DbType.Int32);
            p.Add("Nombre", Data.Nombre, System.Data.DbType.String);
            p.Add("FechaInicio", Data.FechaInicio, System.Data.DbType.Date);
            p.Add("FechaFin", Data.FechaFin, System.Data.DbType.Date);
            return await SetWithResult<Int32>(p, QSemana.Insert);
        }

        public async Task Update(Ekilibrate.Model.Entity.Administrador.clsSemana Data)
        {
            var p = new DynamicParameters();
            p.Add("Id", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("Semana", Data.Semana, System.Data.DbType.Int32);
            p.Add("Nombre", Data.Nombre, System.Data.DbType.String);
            p.Add("FechaInicio", Data.FechaInicio, System.Data.DbType.Date);
            p.Add("FechaFin", Data.FechaFin, System.Data.DbType.Date);
            await Set(p, QSemana.Update);
        }

        public async Task Delete(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, System.Data.DbType.Int32);
            await Set(p, QSemana.Delete);
        }
    }
}
