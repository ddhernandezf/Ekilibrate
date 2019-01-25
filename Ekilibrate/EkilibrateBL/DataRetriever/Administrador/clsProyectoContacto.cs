using Autofac;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.DataRetriever.Administrador
{
    public class clsProyectoContacto : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Administrador.clsProyectoContacto, Int32>
    {
        public clsProyectoContacto(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsProyectoContacto>> GetProyectoContacto(Ekilibrate.Model.Entity.Administrador.clsProyectoContactoFiltro Filtro)
        {
            var p = new DynamicParameters();

            p.Add("EmpresaId", Filtro.IdEmpresa, System.Data.DbType.Int32);
            p.Add("ProyectoId", Filtro.IdProyecto, System.Data.DbType.Int32);
            return await Get(p, Ekilibrate.BL.Queries.Administrador.QProyectoContacto.List);
        }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsContactoProyecto>> GetContacto(int ProyectoId)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", ProyectoId, System.Data.DbType.Int32);
            return await Get<Ekilibrate.Model.Entity.Administrador.clsContactoProyecto>(p, Ekilibrate.BL.Queries.Administrador.QProyectoContacto.ListbyProyecto);
        }
    }
}
