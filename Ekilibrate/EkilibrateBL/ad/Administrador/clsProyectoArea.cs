using Autofac;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.ad.Administrador
{
    public class clsProyectoArea : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Administrador.clsProyectoArea, Int32>
    {
        public clsProyectoArea(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Add(Ekilibrate.Model.Entity.Administrador.clsProyectoArea Data)
        {

            var p = new DynamicParameters();
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("AreaId", Data.AreaId, System.Data.DbType.Int32);
            await Set(p, Ekilibrate.BL.Queries.Administrador.QProyectoArea.Insert);
        }

        public async Task Delete(Ekilibrate.Model.Entity.Administrador.clsProyectoArea Data)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("AreaId", Data.AreaId, System.Data.DbType.Int32);
            await Set(p, Ekilibrate.BL.Queries.Administrador.QProyectoArea.Delete);
        }
    }
}
