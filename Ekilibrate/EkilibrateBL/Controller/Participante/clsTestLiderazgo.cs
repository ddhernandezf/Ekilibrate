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
    public class clsTestLiderazgo : Ekilibrate.BL.ad.Participante.clsTestLiderazgo
    {
        public clsTestLiderazgo(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Select(Ekilibrate.Model.Entity.Participante.clsTestLiderazgoBase Data)
        {
            var test = await base.GetOne(Data.ParticipanteId, Data.PreguntaId);
            if (test != null)
                await base.Update(Data);
            else
                await base.Insert(Data);
        }
    }
}
