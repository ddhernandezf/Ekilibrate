using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Controller.Administrador
{
    public class clsProyectoContacto : Ekilibrate.ad.Administrador.clsProyectoContacto
    {
        public clsProyectoContacto(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Insert(Ekilibrate.Model.Entity.Administrador.clsProyectoContacto Data)
        {
            await base.Add(Data);
        }
    }
}
