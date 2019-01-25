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
    public class clsSeguimiento : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsSeguimientoBase, Int32>
    {

        public clsSeguimiento(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<clsSeguimientoBase> GetOne(int CitaId)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("CitaId", CitaId, System.Data.DbType.Int32);
                var r = await Get(p, QSeguimiento.GetOne);
                return r.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Insert(clsSeguimientoBase Data)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("ParticipanteId", Data.ParticipanteId, System.Data.DbType.Int16);
                p.Add("NutricionistaId", Data.NutricionistaId, System.Data.DbType.Int16);
                p.Add("CitaId", Data.CitaId, System.Data.DbType.Int32);               
                p.Add("ComentariosRelevantes", Data.ComentariosRelevantes, System.Data.DbType.String);

                await Set(p, QSeguimiento.Insert);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(clsSeguimientoBase Data)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("ParticipanteId", Data.ParticipanteId, System.Data.DbType.Int16);
                p.Add("NutricionistaId", Data.NutricionistaId, System.Data.DbType.Int16);
                p.Add("CitaId", Data.CitaId, System.Data.DbType.Int32);
                p.Add("ComentariosRelevantes", Data.ComentariosRelevantes, System.Data.DbType.String);

                await Set(p, QSeguimiento.Update);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
