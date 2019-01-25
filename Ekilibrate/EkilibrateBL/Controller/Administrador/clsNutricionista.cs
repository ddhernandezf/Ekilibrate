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
using Ekilibrate.Model.Entity.Administrador;

namespace Ekilibrate.BL.Controller
{
    public class clsNutricionista : Ekilibrate.ad.Administrador.clsNutricionista
    {
        public clsNutricionista(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Create(clsNutricionistaBase Data)
        {
            await base.Insert(Data);
        }
    }
}
