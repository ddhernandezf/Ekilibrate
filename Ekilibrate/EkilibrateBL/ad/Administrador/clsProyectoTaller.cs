using Autofac;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ekilibrate.BL.Queries.Administrador;
using Ekilibrate.Model.Administrador;

namespace Ekilibrate.ad.Administrador
{
    public class clsTaller : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Administrador.clsTallerVista, Int32>
    {
        public clsTaller(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Insert(Ekilibrate.Model.Entity.Administrador.clsTallerVista Data)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("SalonId", Data.SalonId, System.Data.DbType.Int32);
            p.Add("TallerId", Data.TallerId, System.Data.DbType.Int32);
            p.Add("GrupoId", Data.GrupoId, System.Data.DbType.Int32);
            p.Add("FacilitadorId", Data.FacilitadorId, System.Data.DbType.Int32);
            p.Add("NoSesiones", Data.NoSesiones, System.Data.DbType.Int32);
            p.Add("DuracionSesiones", Data.DuracionSesiones, System.Data.DbType.Time);
            p.Add("FrecuenciaSesiones", Data.FrecuenciaSesiones, System.Data.DbType.Int32);
            p.Add("FrecuenciaSesionesUnidad", Data.FrecuenciaSesionesUnidad, System.Data.DbType.Int32);
            p.Add("HoraInicio", Data.HoraInicio, System.Data.DbType.Time);
            p.Add("HoraFin", Data.HoraFin, System.Data.DbType.Time);
            p.Add("Lunes", Data.Lunes, System.Data.DbType.Boolean);
            p.Add("Martes", Data.Martes, System.Data.DbType.Boolean);
            p.Add("Miercoles", Data.Miercoles, System.Data.DbType.Boolean);
            p.Add("Jueves", Data.Jueves, System.Data.DbType.Boolean);
            p.Add("Viernes", Data.Viernes, System.Data.DbType.Boolean);
            p.Add("Sabado", Data.Sabado, System.Data.DbType.Boolean);
            p.Add("Domingo", Data.Domingo, System.Data.DbType.Boolean);
            return await SetWithResult<Int32>(p, QTallerProyecto.Insert);
        }

        public async Task Update(Ekilibrate.Model.Entity.Administrador.clsTallerVista Data)
        {
            var p = new DynamicParameters();
            p.Add("Id", Data.Id, System.Data.DbType.Int32);
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("SalonId", Data.SalonId, System.Data.DbType.Int32);
            p.Add("TallerId", Data.TallerId, System.Data.DbType.Int32);
            p.Add("GrupoId", Data.GrupoId, System.Data.DbType.Int32);
            p.Add("FacilitadorId", Data.FacilitadorId, System.Data.DbType.Int32);
            p.Add("NoSesiones", Data.NoSesiones, System.Data.DbType.Int32);
            p.Add("DuracionSesiones", Data.DuracionSesiones, System.Data.DbType.Time);
            p.Add("FrecuenciaSesiones", Data.FrecuenciaSesiones, System.Data.DbType.Int32);
            p.Add("FrecuenciaSesionesUnidad", Data.FrecuenciaSesionesUnidad, System.Data.DbType.Int32);
            p.Add("HoraInicio", Data.HoraInicio, System.Data.DbType.Time);
            p.Add("HoraFin", Data.HoraFin, System.Data.DbType.Time);
            p.Add("Lunes", Data.Lunes, System.Data.DbType.Boolean);
            p.Add("Martes", Data.Martes, System.Data.DbType.Boolean);
            p.Add("Miercoles", Data.Miercoles, System.Data.DbType.Boolean);
            p.Add("Jueves", Data.Jueves, System.Data.DbType.Boolean);
            p.Add("Viernes", Data.Viernes, System.Data.DbType.Boolean);
            p.Add("Sabado", Data.Sabado, System.Data.DbType.Boolean);
            p.Add("Domingo", Data.Domingo, System.Data.DbType.Boolean);
            await Set(p, QTallerProyecto.Update);
        }

        public async Task Delete(Ekilibrate.Model.Entity.Administrador.clsTallerVista Data)
        {
            var p = new DynamicParameters();
            p.Add("Id", Data.Id, System.Data.DbType.Int32);
            await Set(p, QTallerProyecto.Delete);
        }
    }
}
