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
    public class clsColaborador : Ekilibrate.ad.Administrador.clsColaborador
    {
        public clsColaborador(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task<Int32> Create(clsColaboradorBase Data)
        {
            return await base.Insert(Data);
        }
    }
}
