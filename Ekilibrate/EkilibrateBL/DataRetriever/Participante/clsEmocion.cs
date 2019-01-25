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
    public class clsEmocion : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Participante.clsEmocionBase, Int32>
    {
        private ILifetimeScope _lifetimeScope;
        public clsEmocion(ILifetimeScope lifetimeScope) : base(lifetimeScope) { _lifetimeScope = lifetimeScope; }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsEmocion>> GetEmociones(int Participante)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Participante, System.Data.DbType.Int32);
            return await Get<Ekilibrate.Model.Entity.Participante.clsEmocion>(p, QEmocion.List);
        }
    }
}
