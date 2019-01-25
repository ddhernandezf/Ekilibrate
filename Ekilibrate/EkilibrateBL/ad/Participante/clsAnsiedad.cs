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
    public class clsAnsiedad : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Participante.clsAnsiedad,Int32>
    {
        public clsAnsiedad(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Ekilibrate.Model.Entity.Participante.clsAnsiedad> Get(int Participante, int Pregunta)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Participante, System.Data.DbType.Int32);
            p.Add("ID_ANSIEDAD", Pregunta, System.Data.DbType.Int32);
            var res = await Get(p, QRespAnsiedad.Get);
            if (res != null && res.Count() > 0)
                return res.First();

            return null;
        }

        public async Task Insert(clsAnsiedadBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Data.ID_PARTICIPANTE, System.Data.DbType.Int32);
            p.Add("ID_ANSIEDAD", Data.ID_ANSIEDAD, System.Data.DbType.Int32);
            p.Add("RESPUESTA", Data.RESPUESTA, System.Data.DbType.String);
            await Set(p, QRespAnsiedad.Insert);
        }

        public async Task Delete(clsAnsiedadBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Data.ID_PARTICIPANTE, System.Data.DbType.Int32);
            p.Add("ID_ANSIEDAD", Data.ID_ANSIEDAD, System.Data.DbType.Int32);
            await Set(p, QRespAnsiedad.Delete);
        }
    }
}
