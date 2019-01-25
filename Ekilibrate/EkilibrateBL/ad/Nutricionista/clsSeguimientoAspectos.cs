using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Nutricionista;
using Ekilibrate.Model.Entity.Nutricionista;

namespace Ekilibrate.BL.ad.Nutricionista
{
    public class clsSeguimientoAspectos : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsSeguimientoAspectosBase, Int32>
    {

        public clsSeguimientoAspectos(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<clsSeguimientoAspectosBase> GetOne(int CitaId, int AspectoId)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("CitaId", CitaId, System.Data.DbType.Int32);
                p.Add("AspectoId", AspectoId, System.Data.DbType.Int16);
                var r = await Get(p, QSeguimientoAspectos.GetOne);
                return r.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Insert(clsSeguimientoAspectosBase Data)
        {
            try
            {
                var p = GetParameters(Data);
                await Set(p, QSeguimientoAspectos.Insert);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(clsSeguimientoAspectosBase Data)
        {
            try
            {
                var p = GetParameters(Data);
                await Set(p, QSeguimientoAspectos.Update);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DynamicParameters GetParameters(clsSeguimientoAspectosBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ParticipanteId", Data.ParticipanteId, System.Data.DbType.Int32);
            p.Add("CitaId", Data.CitaId, System.Data.DbType.Int32);
            p.Add("AspectoId", Data.AspectoId, System.Data.DbType.Int16);
            p.Add("Logro", Data.Logro, System.Data.DbType.Decimal);
            p.Add("Meta", Data.Meta, System.Data.DbType.Decimal);
            p.Add("Observaciones", Data.Observaciones, System.Data.DbType.String);
            return p;
            
        }

    }
}
