using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries;
using Ekilibrate.Model.Catalogos;
using Ekilibrate.ad.Catalogos;

namespace Ekilibrate.BL.Controller
{
    public class clsTipoUsoSalon : Ekilibrate.ad.Catalogos.clsTipoUsoSalon
    {
        public clsTipoUsoSalon(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Create(clsTipoUsoSalonBase Data)
        {
            return await base.Insert(Data);
        }
    }
}
