using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ekilibrate.BL.Controller.Administrador
{
    public class clsProyectoSalon : Ekilibrate.ad.Administrador.clsProyectoSalon
    {
        public clsProyectoSalon(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Insert(Ekilibrate.Model.Entity.Administrador.clsProyectoSalon Data)
        {
            await base.Add(Data);
        }
    }
}
