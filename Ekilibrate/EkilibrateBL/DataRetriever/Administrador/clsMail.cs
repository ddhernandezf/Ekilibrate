using Autofac;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.DataRetriever.Administrador
{
    public class clsMail : Ekilibrate.Data.Access.Common.clsReadOnlyDataAccess<Ekilibrate.Model.Entity.General.clsMensajeCorreo, Int32>
    {

        public clsMail(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<IEnumerable<Ekilibrate.Model.Entity.General.clsMensajeCorreo>> GetCorreos()
        {
            var p = new DynamicParameters();

            return await Get(p, Ekilibrate.BL.Queries.Administrador.QMail.MensajesSinEnviar);
        }


    }
}
