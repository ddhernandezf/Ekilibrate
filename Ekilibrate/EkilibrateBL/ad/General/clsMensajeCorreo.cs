using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Administrador;
using Ekilibrate.Model.Entity.General;

namespace Ekilibrate.ad.General
{
    public class clsMensajeCorreo : Ekilibrate.Data.Access.Common.clsTransactionalDataAccess<Ekilibrate.Model.Entity.General.clsMensajeCorreo, Int32>
    {
        public clsMensajeCorreo(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Insert(Ekilibrate.Model.Entity.General.clsMensajeCorreo Data)
        {
            var p = new DynamicParameters();
            p.Add("Asunto", Data.Asunto, System.Data.DbType.String);
            p.Add("Mensaje", Data.Mensaje, System.Data.DbType.String);
            p.Add("EsHTML", Data.EsHTML, System.Data.DbType.String);
            p.Add("Para", Data.Para, System.Data.DbType.String);
            p.Add("EsLista", Data.EsLista, System.Data.DbType.String);
            p.Add("FechaEnvio", Data.FechaEnvio, System.Data.DbType.DateTime);
            p.Add("EstadoEnvio", Data.EstadoEnvio, System.Data.DbType.String);
            return await SetWithResult<Int32>(p, QMail.Insert);
        }

        public async Task<Int32> Update(Ekilibrate.Model.Entity.General.clsMensajeCorreo Data)
        {
            var p = new DynamicParameters();
            p.Add("EstadoEnvio", Data.EstadoEnvio, System.Data.DbType.String);
            p.Add("Id", Data.Id, System.Data.DbType.Int32);
            return await SetWithResult<Int32>(p, QMail.Update);
        }      
    }
}
