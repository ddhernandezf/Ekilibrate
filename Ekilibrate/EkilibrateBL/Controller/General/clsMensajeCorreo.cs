using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries;
using Ekilibrate.Model.Entity.General;
using Ekilibrate.ad.General;


namespace Ekilibrate.BL.Controller.General
{
    public class clsMensajeCorreo : Ekilibrate.ad.General.clsMensajeCorreo
    {
        public clsMensajeCorreo(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Update(IEnumerable<Ekilibrate.Model.Entity.General.clsMensajeCorreo> Data)
        {
            var result = 0;
            foreach (var mail in Data)
            {
                result = await base.Update(mail);
            }            

            return result;
        }

    }
}
