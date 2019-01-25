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
    public class clsDiagnostico : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Diagnostico, Int32>
    {

        public clsDiagnostico(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Diagnostico> GetOne(int ParticipanteId, int CitaId)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("ParticipanteId", ParticipanteId, System.Data.DbType.Int16);
                p.Add("CitaId", CitaId, System.Data.DbType.Int16);
                var r = await Get(p, QDiagnostico.GetOne);
                if (r != null)
                    return r.FirstOrDefault();
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Insert(Diagnostico Data)
        {
            try
            {
                var p = GetParams(Data);
                await Set(p, QDiagnostico.Insert);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Update(Diagnostico Data)
        {
            try
            {
                var p = GetParams(Data);
                await Set(p, QDiagnostico.Update);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DynamicParameters GetParams(Diagnostico Data)
        {
            var p = new DynamicParameters();
            p.Add("ParticipanteId", Data.ParticipanteId, System.Data.DbType.Int16);
            p.Add("CitaId", Data.CitaId, System.Data.DbType.Int16);
            p.Add("NutricionistaId", Data.NutricionistaId, System.Data.DbType.Int16);
            p.Add("Peso", Data.Peso, System.Data.DbType.Double);
            p.Add("Estatura", Data.Estatura, System.Data.DbType.Double);
            p.Add("CircunferenciaMuneca", Data.CircunferenciaMuneca, System.Data.DbType.Double);
            p.Add("CircunferenciaAbdominal", Data.CircunferenciaAbdominal, System.Data.DbType.Double);
            p.Add("CircunferenciaCadera", Data.CircunferenciaCadera, System.Data.DbType.Double);
            p.Add("PorcentajeGrasa", Data.PorcentajeGrasa, System.Data.DbType.Double);
            p.Add("Colesterol", Data.Colesterol, System.Data.DbType.Double);
            p.Add("Triglicerios", Data.Triglicerios, System.Data.DbType.Double);
            p.Add("Glucosa", Data.Glucosa, System.Data.DbType.Double);
            p.Add("PresionArterial", Data.PresionArterial, System.Data.DbType.Double);
            p.Add("Observaciones", Data.Observaciones, System.Data.DbType.String);
            p.Add("ComentariosRelevantes", Data.ComentariosRelevantes, System.Data.DbType.String);
            p.Add("PresionArterial2", Data.PresionArterial2, System.Data.DbType.Double);
            p.Add("Genero", Data.Genero, System.Data.DbType.String);
            p.Add("NivelActividad", Data.NivelActividad, System.Data.DbType.Int32);
            return p;
        }
    }
}
