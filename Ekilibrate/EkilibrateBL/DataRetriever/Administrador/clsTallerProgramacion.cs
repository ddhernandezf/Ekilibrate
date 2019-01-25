using Autofac;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.DataRetriever.Administrador
{
    public class clsTallerProgramacion : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Proyecto.clsTallerProgramacion, List<Int32>>
    {
        public clsTallerProgramacion(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Proyecto.clsTallerProgramacion>> GetTallerProgramacionList(int ProyectoId)
        {
            var p = new DynamicParameters();

            p.Add("ProyectoId", ProyectoId, System.Data.DbType.Int32);
            var result = await Get(p, Ekilibrate.BL.Queries.Administrador.QTallerProgramacion.List);
            return result;
        }
    }
}