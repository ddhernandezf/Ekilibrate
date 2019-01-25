using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries;

namespace Ekilibrate.BL.DataRetriever
{
    public class clsTipoUsoSalon : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Catalogos.clsTipoUsoSalonBase, Int32>
    {
        public clsTipoUsoSalon(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Catalogos.clsTipoUsoSalonBase>> GetTipoUsoSalon(Ekilibrate.Model.Catalogos.clsTipoUsoSalonFiltro Filtro)
        {
            var p = new DynamicParameters();

            if (Filtro.Id > 0) p.Add("Id", Filtro.Id, System.Data.DbType.Int32); 

            //p.Add("Activity", Activity, System.Data.DbType.Int32);
            return await Get(p, Ekilibrate.BL.Queries.Catalogos.QTipoUsoSalon.List);
        }
    }
}
