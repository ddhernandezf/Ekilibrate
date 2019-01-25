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
    public class clsDiagnosticoAlimentos : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Model.Entity.Nutricionista.DiagnosticoAlimentos, Int32>
    {
        public clsDiagnosticoAlimentos(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Model.Entity.Nutricionista.DiagnosticoAlimentos>> GetAlimentos(int Participante, int CitaId)
        {
            var p = new DynamicParameters();
            p.Add("Participante", Participante, System.Data.DbType.Int32);
            p.Add("CitaId", CitaId, System.Data.DbType.Int32);
            return await Get(p, QAlimentacion.Alimentos);
        }

        public async Task<Model.Entity.Nutricionista.Diagnostico> GetDiagnostico(int ParticipanteId, int CitaId)
        {
            string q = QAlimentacion.Diagnostico;
            var p = new DynamicParameters();
            p.Add("ParticipanteId", ParticipanteId, System.Data.DbType.Int32);
            p.Add("CitaId", CitaId, System.Data.DbType.Int32);
                        
            var res = await Get <Model.Entity.Nutricionista.Diagnostico>(p, q);
            if (res != null && res.Count() > 0)
                return res.First();
            else
                return null;
        }
    }
}
