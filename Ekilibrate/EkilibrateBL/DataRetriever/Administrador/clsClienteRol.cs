using Autofac;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.DataRetriever.Administrador
{
    public class clsClienteRol : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Administrador.clsClienteRolBase, Int32>
    {
        public clsClienteRol(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Administrador.clsClienteRolBase>> GetClienteRol(Ekilibrate.Model.Administrador.clsClienteRolFiltro Filtro)
        {
            var p = new DynamicParameters();

            p.Add("Id", Filtro.Id, System.Data.DbType.Int32);

            //p.Add("Activity", Activity, System.Data.DbType.Int32);
            return await Get(p, Ekilibrate.BL.Queries.Administrador.QClienteRol.List);
        }
    }
}
