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
    public class clsEmpresa : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Administrador.clsEmpresaBase, Int32>
    {
        public clsEmpresa(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsEmpresaContacto>> GetEmpresas(Ekilibrate.Model.Entity.Administrador.clsEmpresaFiltro Filtro)
        {
            var p = new DynamicParameters();

            if (Filtro.Id > 0) p.Add("Id", Filtro.Id, System.Data.DbType.Int32); 

            //p.Add("Activity", Activity, System.Data.DbType.Int32);
           // IEnumerable<Ekilibrate.Model.Entity.Administrador.clsEmpresaContacto> list = await Get<Ekilibrate.Model.Entity.Administrador.clsEmpresaContacto>(p, QEmpresa.EmpresaContacto);
            return await Get<Ekilibrate.Model.Entity.Administrador.clsEmpresaContacto>(p, QEmpresa.EmpresaContacto);
        }
    }
}
