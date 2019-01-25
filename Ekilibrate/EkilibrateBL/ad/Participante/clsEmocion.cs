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
    public class clsEmocion : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsEmocionBase, Int32>
    {
        public clsEmocion(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Insert(clsEmocionBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_ANSIEDAD", Data.ID_ANSIEDAD, System.Data.DbType.Int32);
            p.Add("RESPUESTA", Data.RESPUESTA, System.Data.DbType.String);
            return await SetWithResult<Int32>(p, QDiagnostico.Insert);

        }
        public async Task Update(clsEmocionBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_ANSIEDAD", Data.ID_ANSIEDAD, System.Data.DbType.Int32);
            p.Add("RESPUESTA", Data.RESPUESTA, System.Data.DbType.String);
            await SetWithResult<Int32>(p, QDiagnostico.Update);
        }

        public async Task Delete(int ID_PARTICIPANTE)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", ID_PARTICIPANTE, System.Data.DbType.Int32);
            await Set(p, QEmocion.Delete);
        }

    }
}

