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
    public class clsComunicacion : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsComunicacionBase, Int32>
    {
        public clsComunicacion(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }
        public async Task<Int32> Insert(clsComunicacionBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_PREGUNTA", Data.ID_PREGUNTA, System.Data.DbType.Int32);
            p.Add("EN_ABSOLUTO", Data.EN_ABSOLUTO, System.Data.DbType.String);
            p.Add("UN_POCO", Data.UN_POCO, System.Data.DbType.String);
            p.Add("BASTANTE", Data.BASTANTE, System.Data.DbType.String);
            p.Add("MUCHO", Data.MUCHO, System.Data.DbType.String);
            p.Add("MUCHISIMO", Data.MUCHISIMO, System.Data.DbType.String);
            return await SetWithResult<Int32>(p, QComunicacion.Insert);
        }
        public async Task Update(clsComunicacionBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_PREGUNTA", Data.ID_PREGUNTA, System.Data.DbType.Int32);
            p.Add("EN_ABSOLUTO", Data.EN_ABSOLUTO, System.Data.DbType.String);
            p.Add("UN_POCO", Data.UN_POCO, System.Data.DbType.String);
            p.Add("BASTANTE", Data.BASTANTE, System.Data.DbType.String);
            p.Add("MUCHO", Data.MUCHO, System.Data.DbType.String);
            p.Add("MUCHISIMO", Data.MUCHISIMO, System.Data.DbType.String);
            await SetWithResult<Int32>(p, QComunicacion.Update);
        }

        public async Task Delete(int ID_PARTICIPANTE)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", ID_PARTICIPANTE, System.Data.DbType.Int32);
            await Set(p, QComunicacion.Delete);
        }
    }
}
