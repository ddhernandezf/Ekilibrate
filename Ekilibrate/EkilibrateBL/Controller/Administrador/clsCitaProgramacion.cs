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

 
namespace Ekilibrate.BL.Controller.Administrador
{
    public class clsCitaProgramacion : Ekilibrate.ad.Administrador.clsCitaProgramacion
    {
        public clsCitaProgramacion(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Reprograma_update(Ekilibrate.Model.Entity.Administrador.clsCitaProgramacion Data)
        {
            Data.Cancelada = true;
            await base.UpdateCancelado(Data);
           
        }

        public async Task<Int32> Reprograma_Insert(Ekilibrate.Model.Entity.Administrador.clsCitaProgramacion Data)
        {           
            Data.Cancelada = false;
            return await base.InsertCancelado(Data);
        }


    }
}
