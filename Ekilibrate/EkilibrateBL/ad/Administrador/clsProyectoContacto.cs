using Autofac;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.ad.Administrador
{
    public class clsProyectoContacto : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Administrador.clsProyectoContacto, Int32>
    {
        public clsProyectoContacto(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Add(Ekilibrate.Model.Entity.Administrador.clsProyectoContacto Data)
        {
        
            var p = new DynamicParameters();
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("ContactoId", Data.ContactoId, System.Data.DbType.Int32);
            await Set(p, Ekilibrate.BL.Queries.Administrador.QProyectoContacto.Insert);
        }

        public async Task Delete(Ekilibrate.Model.Entity.Administrador.clsProyectoContacto Data)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("ContactoId", Data.ContactoId, System.Data.DbType.Int32);
            await Set(p, Ekilibrate.BL.Queries.Administrador.QProyectoContacto.Delete);
        }
    }
}
