using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries;
using Ekilibrate.Model.Entity.Administrador;
using Ekilibrate.ad.Administrador;

namespace Ekilibrate.BL.Controller
{
    public class clsTaller : Ekilibrate.ad.Administrador.clsTaller
    {
        public clsTaller(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Create(clsTallerVista Data)
        {
            return await base.Insert(Data);
        }
    }
}
