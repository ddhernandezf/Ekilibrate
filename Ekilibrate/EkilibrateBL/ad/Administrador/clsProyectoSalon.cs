using Autofac;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.ad.Administrador
{
    public class clsProyectoSalon : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Administrador.clsProyectoSalon, Int32>
    {
        public clsProyectoSalon(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Add(Ekilibrate.Model.Entity.Administrador.clsProyectoSalon Data)
        {
        
            var p = new DynamicParameters();
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("SalonId", Data.SalonId, System.Data.DbType.Int32);
            await Set(p, Ekilibrate.BL.Queries.Administrador.QProyectoSalon.Insert);
        }

        public async Task Delete(Ekilibrate.Model.Entity.Administrador.clsProyectoSalon Data)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("SalonId", Data.SalonId, System.Data.DbType.Int32);
            await Set(p, Ekilibrate.BL.Queries.Administrador.QProyectoSalon.Delete);
        }
    }
}
