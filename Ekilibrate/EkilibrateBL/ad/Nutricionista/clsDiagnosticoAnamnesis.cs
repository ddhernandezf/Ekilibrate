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
    public class clsDiagnosticoAnamnesis: Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<DiagnosticoAnamnesis, Int32>
    {

        public clsDiagnosticoAnamnesis(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> InsertAnamnesis(DiagnosticoItem Data)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("ParticipanteId", Data.ParticipanteId, System.Data.DbType.Int16);
                p.Add("CitaId", Data.CitaId, System.Data.DbType.Int16);
                p.Add("NutricionistaId", Data.NutricionistaId, System.Data.DbType.Int16);
                p.Add("GrupoAlimentoId", Data.GrupoAlimentoId, System.Data.DbType.Int16);
                p.Add("TiempoComidaId", Data.TiempoComidaId, System.Data.DbType.Int16);
                p.Add("Porciones", Data.Porciones, System.Data.DbType.Int16);
                p.Add("GrupoAlimentoId", Data.GrupoAlimentoId, System.Data.DbType.Int16);

                return await SetWithResult<Int32>(p, QAnamnesis.InsertAnamnesis);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }      
    
    }
}
