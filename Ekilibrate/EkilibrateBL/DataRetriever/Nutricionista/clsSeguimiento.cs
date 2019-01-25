using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Nutricionista;
using Ekilibrate.Model.Entity.Nutricionista;
using Ekilibrate.BL.ad.Nutricionista;

namespace Ekilibrate.BL.DataRetriever.Nutricionista
{
    public class clsSeguimiento : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Model.Entity.Nutricionista.clsSeguimiento, Int32>
    {
        public clsSeguimiento(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Model.Entity.Nutricionista.clsSeguimiento> GetSeguimiento(int CitaId) 
        {
            var p = new DynamicParameters();
            p.Add("CitaId", CitaId, System.Data.DbType.Int32);            
            //p.Add("Activity", Activity, System.Data.DbType.Int32);
            var result = await Get(p, QSeguimiento.Get);
            return result.FirstOrDefault();
        }

        public async Task<Model.Entity.Nutricionista.clsSeguimiento> GetSeguimientoActual(int ParticipanteId)
        {
            var p = new DynamicParameters();
            p.Add("ParticipanteId", ParticipanteId, System.Data.DbType.Int32);
            //p.Add("Activity", Activity, System.Data.DbType.Int32);
            var result = await Get(p, QSeguimiento.GetActual);
            return result.FirstOrDefault();
        }

    }
}
