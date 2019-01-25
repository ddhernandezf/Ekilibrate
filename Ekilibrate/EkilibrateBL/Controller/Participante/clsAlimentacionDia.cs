using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries;
using Ekilibrate.Model.Entity.Participante;
using Ekilibrate.BL.ad.Participante;

namespace Ekilibrate.BL.Controller.Participante
{
    public class clsAlimentacionDia : Ekilibrate.BL.ad.Participante.clsAlimentacionDia
    {
        public clsAlimentacionDia(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Sincronizar(IEnumerable<clsAlimentacionDiaBase> Data)
        {
            foreach(var d in Data)
            if (d.Nuevo)
                await base.Insert(d);
            else
                await base.Update(d);
        }
    }
}
