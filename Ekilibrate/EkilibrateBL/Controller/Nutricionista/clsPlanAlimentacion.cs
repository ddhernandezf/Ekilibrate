using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Nutricionista;
using Ekilibrate.Model.Entity.Nutricionista;
using Ekilibrate.BL.ad.Nutricionista;
using Ekilibrate.Model.Entity.Catalogos;

namespace Ekilibrate.BL.Controller.Nutricionista
{
    public class clsPlanAlimentacion : Ekilibrate.BL.ad.Nutricionista.clsPlanAlimentacion
    {
        public clsPlanAlimentacion(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Sincronizar(Model.Entity.Nutricionista.clsPlanAlimentacion Data)
        {
            var item = await base.GetOne(Data.CitaId);
            if (item == null)
                await base.Insert(Data);
            else
                await base.Update(Data);
        }

    }
}
