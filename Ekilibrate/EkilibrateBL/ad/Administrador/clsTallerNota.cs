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
    public class clsTallerNota : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Proyecto.clsTallerNota, List<Int32>>
    {
        public clsTallerNota(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Insert(Ekilibrate.Model.Entity.Proyecto.clsTallerNota Data)
        {
            var p = new DynamicParameters();
            p.Add("TallerId", Data.TallerId, System.Data.DbType.Int32);
            p.Add("NoSesion", Data.NoSesion, System.Data.DbType.Int32);
            p.Add("ParticipanteId", Data.ParticipanteId, System.Data.DbType.Int32);
            p.Add("Asistencia", Data.Asistencia, System.Data.DbType.Int32);
            p.Add("Tarea", Data.Tarea, System.Data.DbType.Int32);
            await Set(p, QTallerNota.Insert);
        }
    }
}
