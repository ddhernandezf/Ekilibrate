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

namespace Ekilibrate.BL.Controller.Administrador
{
    public class clsEmpresa : Ekilibrate.ad.Administrador.clsEmpresa
    {
        public clsEmpresa(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Create(clsEmpresaBase Data)
        {
            return await base.Insert(Data);
        }
    }
}
