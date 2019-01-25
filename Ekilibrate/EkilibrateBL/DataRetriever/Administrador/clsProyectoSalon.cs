using Autofac;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.DataRetriever.Administrador
{
    public class clsProyectoSalon : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Administrador.clsProyectoSalon, Int32>
    {
        public clsProyectoSalon(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsProyectoSalon>> GetPrpyectoSalon(Ekilibrate.Model.Entity.Administrador.clsProyectoSalonFiltro Filtro)
        {
            var p = new DynamicParameters();

            p.Add("EmpresaId", Filtro.IdEmpresa, System.Data.DbType.Int32);
            p.Add("ProyectoId", Filtro.IdProyecto, System.Data.DbType.Int32);

            //p.Add("Activity", Activity, System.Data.DbType.Int32);
            return await Get(p, Ekilibrate.BL.Queries.Administrador.QProyectoSalon.List);
        }
    }
}
