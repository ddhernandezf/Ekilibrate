using Autofac;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.DataRetriever.Administrador
{
    public class clsAsistente : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.Administrador.clsAsistenteBase, Int32>
    {
        public clsAsistente(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.Administrador.clsAsistenteBase>> GetAsistente(Ekilibrate.Model.Entity.Administrador.clsAsistenteFiltro Filtro)
        {
            var p = new DynamicParameters();

            if (Filtro.ProyectoId > 0) p.Add("ProyectoId", Filtro.ProyectoId, System.Data.DbType.Int32);

            //p.Add("Activity", Activity, System.Data.DbType.Int32);
            return await Get(p, Ekilibrate.BL.Queries.Administrador.QAsistente.List);
        }
    }
}
