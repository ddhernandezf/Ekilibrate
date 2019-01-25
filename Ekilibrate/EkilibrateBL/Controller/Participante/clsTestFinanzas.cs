using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries;
using Ekilibrate.Model.Entity.Participante;
using Ekilibrate.ad.Participante;

namespace Ekilibrate.BL.Controller.Participante
{
    public class clsTestFinanzas : Ekilibrate.ad.Participante.clsTestFinanzas
    {
        public clsTestFinanzas(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Create(Ekilibrate.Model.Entity.Participante.clsTestFinanzas Data)
        {
            var test = await base.GetOne(Data.ParticipanteId, Data.PreguntaId);
            if (test == null) 
                await base.Insert(Data);
        }
        
        public async Task Select(Ekilibrate.Model.Entity.Participante.clsTestFinanzas Data)
        {
            var test = await base.GetOne(Data.ParticipanteId, Data.PreguntaId);
            if (test != null)
                await base.Update(Data);
            else
                await base.Insert(Data);
        }
    }
}
