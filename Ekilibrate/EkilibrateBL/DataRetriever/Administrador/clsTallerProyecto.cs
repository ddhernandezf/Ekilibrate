using Autofac;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.DataRetriever.Administrador
{
    public class clsTallerProyecto : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Administrador.clsTallerVista, Int32>
    {
        public clsTallerProyecto(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsTallerVista>> GetTallerProyecto(Ekilibrate.Model.Entity.Administrador.clsTallerFiltro Filtro)
        {
            var p = new DynamicParameters();

            p.Add("ProyectoId", Filtro.IdProyecto, System.Data.DbType.Int32);

            //p.Add("Activity", Activity, System.Data.DbType.Int32);
            var result = await Get(p, Ekilibrate.BL.Queries.Administrador.QTallerProyecto.List);
            result.ToList().ForEach(x =>
            {
                x.DDuracionSesiones = new DateTime().Add(x.DuracionSesiones);
                x.DHoraFin = new DateTime().Add(x.HoraFin);
                x.DHoraInicio = new DateTime().Add(x.HoraInicio);
            });
            return result;
        }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsTallerBase>> GetList(int ProyectoId)
        {
            var p = new DynamicParameters();

            p.Add("ProyectoId", ProyectoId, System.Data.DbType.Int32);
            var result = await Get(p, Ekilibrate.BL.Queries.Administrador.QTallerProyecto.List);
            return result;
        }
    }
}
