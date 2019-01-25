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
    public class clsDiagnosticoAlimentos : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<DiagnosticoAlimentacion, Int32>
    {

        public clsDiagnosticoAlimentos(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> InsertAlimentacion(DiagnosticoAlimentacion Data)
        {
            try
            {
                var p = new DynamicParameters();
                

                return await SetWithResult<Int32>(p, QAlimentacion.Insert);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<DiagnosticoAlimentacion> GetOne(int ParticipanteId, int CitaId, int AlimentoId)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("ParticipanteId", ParticipanteId, System.Data.DbType.Int16);
                p.Add("CitaId", CitaId, System.Data.DbType.Int16);
                p.Add("AlimentoId", AlimentoId, System.Data.DbType.Int16);
                var r = await Get(p, QAlimentacion.GetOne);
                return r.FirstOrDefault();                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Insert(DiagnosticoAlimentacion Data)
        {
            try
            {
                var p = GetParams(Data);
                await Set(p, QAlimentacion.Insert);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(DiagnosticoAlimentacion Data)
        {
            try
            {
                var p = GetParams(Data);
                await Set(p, QAlimentacion.Update);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DynamicParameters GetParams(DiagnosticoAlimentacion Data)
        {
            var p = new DynamicParameters();
            p.Add("Id", Data.Id, System.Data.DbType.Int16);
            p.Add("ParticipanteId", Data.ParticipanteId, System.Data.DbType.Int16);
            p.Add("CitaId", Data.CitaId, System.Data.DbType.Int16);
            p.Add("NutricionistaId", Data.NutricionistaId, System.Data.DbType.Int16);
            p.Add("AlimentoId", Data.AlimentoId, System.Data.DbType.Int16);
            p.Add("Dias", Data.Dias, System.Data.DbType.Int16);
            p.Add("Porciones", Data.Porciones, System.Data.DbType.Int16);
            return p;
        }
    }
}
