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
    public class clsAlimentacion : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsAlimentacionBase, Int32>
    {
        public clsAlimentacion(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }
        public async Task<Int32> Insert(clsAlimentacionBase Data)
        {
            var p = GetParams(Data);
            return await SetWithResult<Int32>(p, QAlimentacion.Insert);
        }
        public async Task Update(clsAlimentacionBase Data)
        {
            var p = GetParams(Data);
            await SetWithResult<Int32>(p, QAlimentacion.Update);
        }

        public async Task Delete(int ID_PARTICIPANTE)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", ID_PARTICIPANTE, System.Data.DbType.Int32);
            await Set(p, QAlimentacion.Delete);
        }

        private DynamicParameters GetParams(clsAlimentacionBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Data.ID_PARTICIPANTE, System.Data.DbType.Int32);
            p.Add("DESAYUNO", Data.DESAYUNO, System.Data.DbType.Boolean);
            p.Add("REFACCION_AM", Data.REFACCION_AM, System.Data.DbType.Boolean);
            p.Add("ALMUERZO", Data.ALMUERZO, System.Data.DbType.Boolean);
            p.Add("REFACCION_TARDE", Data.REFACCION_TARDE, System.Data.DbType.Boolean);
            p.Add("CENA", Data.CENA, System.Data.DbType.Boolean);
            p.Add("REFACCION_NOCHE", Data.REFACCION_NOCHE, System.Data.DbType.Boolean);
            p.Add("ID_VASOS", Data.ID_VASOS, System.Data.DbType.Int32);
            p.Add("CUCHARADAS_DIARIAS", Data.CUCHARADAS_DIARIAS, System.Data.DbType.Int32);
            p.Add("SAL", Data.SAL, System.Data.DbType.Boolean);
            p.Add("COMIDA_FAVORITA", Data.COMIDA_FAVORITA, System.Data.DbType.String);
            p.Add("COMIDA_NO_FAVORITA", Data.COMIDA_NO_FAVORITA, System.Data.DbType.String);
            p.Add("COMIDA_DANINA", Data.COMIDA_DANINA, System.Data.DbType.String);
            return p;
        }
    }
}
