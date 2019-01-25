using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Participante;
using Ekilibrate.Model.Entity.Participante;

namespace Ekilibrate.BL.ad.Participante
{
    public class clsEnfermedad : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Participante.clsEnfermedad,Int32>
    {
        public clsEnfermedad(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsEnfermedad>> GetEnfermedad(int Participante, int Enfermedad)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Participante, System.Data.DbType.Int32);
            p.Add("ID_ENFERMEDAD", Enfermedad, System.Data.DbType.Int32);
            return await Get(p, QEnfermedad.Get);
        }

        public async Task Insert(clsEnfermedadBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE",Data.ID_PARTICIPANTE,System.Data.DbType.Int32);
            p.Add("ID_ENFERMEDAD", Data.ID_ENFERMEDAD, System.Data.DbType.Int32);
            await Set(p, QEnfermedad.Insert);
        }

        public async Task Delete(clsEnfermedadBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Data.ID_PARTICIPANTE, System.Data.DbType.Int32);
            p.Add("ID_ENFERMEDAD", Data.ID_ENFERMEDAD, System.Data.DbType.Int32);
            await Set(p, QEnfermedad.Delete);
        }
    }
}
