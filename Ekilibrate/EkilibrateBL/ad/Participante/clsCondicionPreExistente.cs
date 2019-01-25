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
    public class clsCondicionPreExistente : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.Participante.clsCondicionPreExistente, Int32>
    {
        public clsCondicionPreExistente(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Ekilibrate.Model.Entity.Participante.clsCondicionPreExistente> Get(int Participante, int Condicion)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Participante, System.Data.DbType.Int32);
            p.Add("ID_CONDICION", Condicion, System.Data.DbType.Int32);
            var result = await Get(p, QCondicionPreExistente.One);
            if (result != null)
                return result.First();
            else
                return null;
        }

        public async Task Insert(clsCondicionPreExistenteBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Data.ID_PARTICIPANTE, System.Data.DbType.Int32);
            p.Add("ID_CONDICION", Data.ID_CONDICION, System.Data.DbType.Int32);
            p.Add("RESPUESTA", 1, System.Data.DbType.String);
            await Set(p, QCondicionPreExistente.Insert);
        }

        public async Task Delete(clsCondicionPreExistenteBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Data.ID_PARTICIPANTE, System.Data.DbType.Int32);
            p.Add("ID_CONDICION", Data.ID_CONDICION, System.Data.DbType.Int32);
            await Set(p, QCondicionPreExistente.Delete);
        }
    }
}
