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
    public class clsTiempo : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsTiempoBase, Int32>
    {
        public clsTiempo(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }
        public async Task<Int32> Insert(clsTiempoBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_PREGUNTA", Data.ID_PREGUNTA, System.Data.DbType.Int32);
            p.Add("SIEMPRE", Data.SIEMPRE, System.Data.DbType.String);
            p.Add("FRECUENTE", Data.FRECUENTE, System.Data.DbType.String);
            p.Add("CASI_NUNCA", Data.CASI_NUNCA, System.Data.DbType.String);
            p.Add("NUNCA", Data.NUNCA, System.Data.DbType.String);
            
            return await SetWithResult<Int32>(p, QTiempo.Insert);
        }
        public async Task Update(clsTiempoBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_PREGUNTA", Data.ID_PREGUNTA, System.Data.DbType.Int32);
            p.Add("SIEMPRE", Data.SIEMPRE, System.Data.DbType.String);
            p.Add("FRECUENTE", Data.FRECUENTE, System.Data.DbType.String);
            p.Add("CASI_NUNCA", Data.CASI_NUNCA, System.Data.DbType.String);
            p.Add("NUNCA", Data.NUNCA, System.Data.DbType.String);
            await SetWithResult<Int32>(p, QTiempo.Update);
        }

        public async Task Delete(int ID_PARTICIPANTE)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", ID_PARTICIPANTE, System.Data.DbType.Int32);
            await Set(p, QTiempo.Delete);
        }
    }
}
