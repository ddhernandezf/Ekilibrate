using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries;
using Ekilibrate.Model.Administrador;
using Ekilibrate.ad.Administrador;

namespace Ekilibrate.BL.Controller.Administrador
{
    public class clsClienteRol : Ekilibrate.ad.Administrador.clsClienteRol
    {
        public clsClienteRol(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Create(clsClienteRolBase Data)
        {
            return await base.Insert(Data);
        }
    }
}
