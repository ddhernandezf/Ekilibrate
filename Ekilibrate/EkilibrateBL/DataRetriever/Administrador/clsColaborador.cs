using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Administrador;

namespace Ekilibrate.BL.DataRetriever.Administrador
{
    public class clsColaborador : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Administrador.clsColaboradorBase, Int32>
    {
        public clsColaborador(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsColaboradorBase>> GetColaborador(Ekilibrate.Model.Entity.Administrador.clsColaboradorFiltro Filtro)
        {
            var p = new DynamicParameters();

            if (Filtro.Id > 0) p.Add("Id", Filtro.Id, System.Data.DbType.Int32);

            //p.Add("Activity", Activity, System.Data.DbType.Int32);
            return await Get(p, QColaboradores.List);
        }
    }
}
