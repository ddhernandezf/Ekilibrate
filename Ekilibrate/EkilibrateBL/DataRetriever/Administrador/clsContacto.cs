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
    public class clsContacto : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Administrador.clsContactoBase, Int32>
    {
        public clsContacto(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsContactoBase>> GetContacto(Ekilibrate.Model.Entity.Administrador.clsContactoFiltro Filtro)
        {
            var p = new DynamicParameters();
            p.Add("EmpresaId", Filtro.EmpresaId, System.Data.DbType.Int32);
            
            //p.Add("Activity", Activity, System.Data.DbType.Int32);
            return await Get(p, QContaco.List);
        }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsContactoBase>> GetContactos(int EmpresaId)
        {
            var p = new DynamicParameters();
            p.Add("EmpresaId", EmpresaId, System.Data.DbType.Int32);
            return await Get(p, QContaco.List);
        }
    }
}
