using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Participante;
namespace Ekilibrate.BL.DataRetriever.Participante
{
    public class clsCondicionPreExistente : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Participante.clsCondicionPreExistente,Int32> 
    {
        public clsCondicionPreExistente(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }
        public async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsCondicionPreExistente>> GetPreExistentes(Ekilibrate.Model.Entity.Participante.clsCondicionPreExistenteFiltro Filtro)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Filtro.ID_PARTICIPANTE, System.Data.DbType.Int32);
            return await Get(p, QCondicionPreExistente.List);

        }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsCondicionPreExistente>> GetPreExistentes(int Participante)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Participante, System.Data.DbType.Int32);
            return await Get(p, QCondicionPreExistente.List);
        }
    }
}
