using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Controller.Administrador
{
    public class clsProyectoArea : Ekilibrate.ad.Administrador.clsProyectoArea
    {
        public clsProyectoArea(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Insert(Ekilibrate.Model.Entity.Administrador.clsProyectoArea Data)
        {
            await base.Add(Data);
        }
    }
}
