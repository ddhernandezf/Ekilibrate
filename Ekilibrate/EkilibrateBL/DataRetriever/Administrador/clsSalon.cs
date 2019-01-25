using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries;

namespace Ekilibrate.BL.DataRetriever
{
    public class clsSalon : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Administrador.clsSalonBase, Int32>
    {
        public clsSalon(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsSalonBase>> GetSalon(Ekilibrate.Model.Entity.Administrador.clsSalonFiltro Filtro)
        {
            var p = new DynamicParameters();
            if (Filtro.ProyectoId > 0)
            {
                p.Add("ProyectoId", Filtro.ProyectoId, System.Data.DbType.Int32);
                return await Get(p, Ekilibrate.BL.Queries.Administrador.QSalon.ListPorProyecto);
            }
            if (Filtro.EmpresaId > 0) p.Add("EmpresaId", Filtro.EmpresaId, System.Data.DbType.Int32);

            if (Filtro.Id > 0) p.Add("Id", Filtro.Id, System.Data.DbType.Int32);


            //p.Add("Activity", Activity, System.Data.DbType.Int32);
            return await Get(p, Ekilibrate.BL.Queries.Administrador.QSalon.List);
        }
    }
}
