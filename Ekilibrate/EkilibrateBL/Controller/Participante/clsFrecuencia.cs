using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries;
using Ekilibrate.Model.Entity.Participante;
using Ekilibrate.BL.ad.Participante;

namespace Ekilibrate.BL.Controller.Participante
{
    public class clsFrecuencia : Ekilibrate.BL.ad.Participante.clsFrecuencia
    {
        public clsFrecuencia(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Create(Ekilibrate.Model.Entity.Participante.clsFrecuencia Data)
        {
             await base.Insert(Data);
        }
        
    }
}
