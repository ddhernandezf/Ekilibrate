using Autofac;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ekilibrate.BL.Queries.Administrador;
using Ekilibrate.Model.Administrador;

namespace Ekilibrate.ad.Administrador
{
    public class clsTallerProgramacion : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Proyecto.clsTallerProgramacion, List<Int32>>
    {
        public clsTallerProgramacion(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Insert(Ekilibrate.Model.Entity.Proyecto.clsTallerProgramacion Data)
        {
            var p = new DynamicParameters();
            p.Add("TallerId", Data.TallerId, System.Data.DbType.Int32);
            p.Add("NoSesion", Data.NoSesion, System.Data.DbType.Int32);
            p.Add("HoraInicio", Data.HoraInicio, System.Data.DbType.Int32);
            p.Add("HoraFin", Data.HoraFin, System.Data.DbType.Int32);
            await Set(p, QTallerProgramacion.Insert);
        }
    }
}
