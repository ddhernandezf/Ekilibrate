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

namespace Ekilibrate.BL.Controller.Cliente
{
    public class clsProyecto : Ekilibrate.ad.Administrador.clsProyecto
    {
        public clsProyecto(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Create(Model.Entity.Administrador.clsProyecto Data)
        {
            return await base.Insert(Data);
        }
    }
}
