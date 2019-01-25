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
using Ekilibrate.Data.Access.Common;

namespace Ekilibrate.BL.Common
{
    public class clsLog : Ekilibrate.ad.General.clsError
    {
        ILifetimeScope _lifetimeScope;
        public clsLog(ILifetimeScope lifetimeScope) : base(lifetimeScope) { _lifetimeScope = lifetimeScope; }
        async public void GuardarLog(Exception ex)
        {
            try
            {
                await base.Insert(new Ekilibrate.Model.Entity.General.Error
                {
                    Mensaje = ex.Message.ToString(),
                    Pila = ex.StackTrace.ToString(),
                    Excepcion = ex.ToString(),
                    Fecha = DateTime.Now
                });

                var DBContext = _lifetimeScope.Resolve<DBTrnContext>();
                DBContext.CommitTransaction();               
            }
            catch
            {
                //throw exc;
            }
        }
    }
}
