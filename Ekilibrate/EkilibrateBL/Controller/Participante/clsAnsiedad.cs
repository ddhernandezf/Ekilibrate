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
    public class clsAnsiedad : Ekilibrate.BL.ad.Participante.clsAnsiedad
    {
        public clsAnsiedad(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Create(clsAnsiedadBase Data)
        {
            var test = await base.Get(Data.ID_PARTICIPANTE, Data.ID_ANSIEDAD);
            if (test == null) 
                await base.Insert(Data);
        }        
    }
}
