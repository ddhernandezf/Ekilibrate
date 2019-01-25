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
    public class clsRiesgo : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Participante.clsRiesgo, Int32>
    {
        public clsRiesgo(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }
        public async Task<Int32> Insert(clsRiesgoBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Data.ID_PARTICIPANTE, System.Data.DbType.Int32);
            p.Add("FUMAR", Data.FUMAR, System.Data.DbType.Boolean);
            p.Add("CODIGO_FRECUENCIA_FUMAR", Data.CODIGO_FRECUENCIA_FUMAR, System.Data.DbType.String);
            p.Add("NUM_CIGARROS", Data.NUM_CIGARROS, System.Data.DbType.Int32);
            p.Add("BEBER", Data.BEBER, System.Data.DbType.Boolean);
            p.Add("CODIGO_FRECUENTE_BEBER", Data.CODIGO_FRECUENTE_BEBER, System.Data.DbType.String);
            p.Add("NUMERO_BEBIDA", Data.NUMERO_BEBIDA, System.Data.DbType.Int32);
             await Set(p, QRiesgo.Insert);
            return Data.ID_PARTICIPANTE;
        }
        public async Task Update(clsRiesgoBase Data)
        {
            var p = new DynamicParameters();
            p.Add("FUMAR", Data.FUMAR, System.Data.DbType.Boolean);
            p.Add("CODIGO_FRECUENCIA_FUMAR", Data.CODIGO_FRECUENCIA_FUMAR, System.Data.DbType.String);
            p.Add("NUM_CIGARROS", Data.NUM_CIGARROS, System.Data.DbType.Int32);
            p.Add("BEBER", Data.BEBER, System.Data.DbType.Boolean);
            p.Add("CODIGO_FRECUENTE_BEBER", Data.CODIGO_FRECUENTE_BEBER, System.Data.DbType.String);
            p.Add("NUMERO_BEBIDA", Data.NUMERO_BEBIDA, System.Data.DbType.Int32);
            p.Add("ID_PARTICIPANTE", Data.ID_PARTICIPANTE, System.Data.DbType.Int32);
            await Set(p, QRiesgo.Update);
        }

        public async Task Delete(int ID_PARTICIPANTE)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", ID_PARTICIPANTE, System.Data.DbType.Int32);
            await Set(p, QRiesgo.Delete);
        }
    }
}
