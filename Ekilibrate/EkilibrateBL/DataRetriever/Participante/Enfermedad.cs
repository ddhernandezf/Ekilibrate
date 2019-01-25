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
    public class clsEnfermedad : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Participante.clsEnfermedad, Int32>
    {
        public clsEnfermedad(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }
        public async Task<IEnumerable<Ekilibrate.Model.Entity.Participante.clsEnfermedad>> GetEnfermedad(int Participante)
        {
            var p = new DynamicParameters();
            p.Add("ID_PARTICIPANTE", Participante, System.Data.DbType.Int32);
            return await Get(p, QEnfermedad.List);
        }

    }
}
