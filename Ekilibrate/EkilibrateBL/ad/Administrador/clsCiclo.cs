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
    public class clsCiclo : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Administrador.clsCiclo, Int32>
    {
        public clsCiclo(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Ekilibrate.Model.Entity.Administrador.clsCiclo> GetOne(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, System.Data.DbType.Int32);
            var r = await Get(p, QCiclo.GetOne);
            return r.FirstOrDefault();
        }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsCiclo>> GetByProyecto(int ProyectoId)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", ProyectoId, System.Data.DbType.Int32);
            return await Get(p, QCiclo.GetByProyecto);            
        }

        public async Task<Int32> Insert(Ekilibrate.Model.Entity.Administrador.clsCiclo Data)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("Finalizado", Data.Finalizado, System.Data.DbType.Int32);
            p.Add("No", Data.No, System.Data.DbType.String);
            p.Add("FechaInicio", Data.FechaInicio, System.Data.DbType.Date);
            p.Add("FechaFin", Data.FechaFin, System.Data.DbType.Date);
            return await SetWithResult<Int32>(p, QCiclo.Insert);
        }

        public async Task Update(Ekilibrate.Model.Entity.Administrador.clsCiclo Data)
        {
            var p = new DynamicParameters();
            p.Add("Id", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("Finalizado", Data.Finalizado, System.Data.DbType.Int32);
            p.Add("No", Data.No, System.Data.DbType.String);
            p.Add("FechaInicio", Data.FechaInicio, System.Data.DbType.Date);
            p.Add("FechaFin", Data.FechaFin, System.Data.DbType.Date);
            await Set(p, QCiclo.Update);
        }

        public async Task Delete(int Id)
        {
            var p = new DynamicParameters();
            p.Add("Id", Id, System.Data.DbType.Int32);
            await Set(p, QCiclo.Delete);
        }
    }
}
