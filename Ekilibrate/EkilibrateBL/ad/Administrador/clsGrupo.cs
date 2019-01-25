using Autofac;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ekilibrate.BL.Queries.Administrador;
using Ekilibrate.Model.Entity.Proyecto;

namespace Ekilibrate.ad.Administrador
{
    public class clsGrupo : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Proyecto.clsGrupo, Int32>
    {
        public clsGrupo(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Ekilibrate.Model.Entity.Proyecto.clsGrupo> GetByNombre(string Nombre, int ProyectoId)
        {
            var p = new DynamicParameters();
            p.Add("Nombre", Nombre, System.Data.DbType.String);
            p.Add("ProyectoId", ProyectoId, System.Data.DbType.Int32);
            var r = await Get(p, QGrupo.GetByNombre);
            return r.FirstOrDefault();
        }

        public async Task<Int32> Insert(Ekilibrate.Model.Entity.Proyecto.clsGrupo Data)
        {
            var p = new DynamicParameters();
            p.Add("Nombre", Data.Nombre, System.Data.DbType.String);
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            return await SetWithResult<Int32>(p, QGrupo.Insert);
        }
    }
}
