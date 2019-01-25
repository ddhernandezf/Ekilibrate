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
    public class clsComunicacionDos : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsComunicacionDosBase, Int32>
    {
        public clsComunicacionDos(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }
        public async Task<Int32> Insert(clsComunicacionDosBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_PREGUNTA", Data.ID_PREGUNTA, System.Data.DbType.Int32);
            p.Add("SIEMPRE_LO_HAGO", Data.SIEMPRE_LO_HAGO, System.Data.DbType.String);
            p.Add("HABITUALMENTEBIT", Data.HABITUALMENTEBIT, System.Data.DbType.String);
            p.Add("MITAD_VECES", Data.MITAD_VECES, System.Data.DbType.String);
            p.Add("RARAMENTE", Data.RARAMENTE, System.Data.DbType.String);
            p.Add("NUNCA", Data.NUNCA, System.Data.DbType.String);            
            return await SetWithResult<Int32>(p, QComunicacionDos.Insert);
        }
        public async Task Update(clsComunicacionDosBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_PREGUNTA", Data.ID_PREGUNTA, System.Data.DbType.Int32);
            p.Add("SIEMPRE_LO_HAGO", Data.SIEMPRE_LO_HAGO, System.Data.DbType.String);
            p.Add("HABITUALMENTEBIT", Data.HABITUALMENTEBIT, System.Data.DbType.String);
            p.Add("MITAD_VECES", Data.MITAD_VECES, System.Data.DbType.String);
            p.Add("RARAMENTE", Data.RARAMENTE, System.Data.DbType.String);
            p.Add("NUNCA", Data.NUNCA, System.Data.DbType.String);            
            await SetWithResult<Int32>(p, QComunicacionDos.Update);
        }

        public async Task Delete(int ID_PARTICIPANTE)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", ID_PARTICIPANTE, System.Data.DbType.Int32);
            await Set(p, QComunicacionDos.Delete);
        }
    }
}
