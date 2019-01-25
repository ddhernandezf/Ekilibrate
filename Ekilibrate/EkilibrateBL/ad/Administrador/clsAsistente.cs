using Autofac;
using Dapper;
using Ekilibrate.Model.Entity.Administrador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.ad.Administrador
{
    public class clsAsistente : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<clsAsistenteBase, Int32>
    {
        public clsAsistente(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Insert(clsAsistenteBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("ColaboradorId", Data.ColaboradorId, System.Data.DbType.Int32);
            await Set(p, Ekilibrate.BL.Queries.Administrador.QAsistente.Insert);
        }

        public async Task Delete(clsAsistenteBase Data)
        {
            var p = new DynamicParameters();
            p.Add("ProyectoId", Data.ProyectoId, System.Data.DbType.Int32);
            p.Add("ColaboradorId", Data.ColaboradorId, System.Data.DbType.Int32);
            await Set(p, Ekilibrate.BL.Queries.Administrador.QAsistente.Delete);
        }
    }
}
