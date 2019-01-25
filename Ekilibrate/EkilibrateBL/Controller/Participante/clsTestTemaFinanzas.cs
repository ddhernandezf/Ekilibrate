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
    public class clsTestTemaFinanzas : Ekilibrate.ad.Participante.clsTestTemaFinanzas
    {
        public clsTestTemaFinanzas(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Select(Ekilibrate.Model.Entity.Participante.clsTestTemaFinanzas Data)
        {
            var test = await base.GetOne(Data.ParticipanteId, Data.TemaId);
            if (test == null)
                await base.Insert(Data);
        }

        public async Task UnSelect(Ekilibrate.Model.Entity.Participante.clsTestTemaFinanzas Data)
        {
            var test = await base.GetOne(Data.ParticipanteId, Data.TemaId);
            if (test != null)
                await base.Delete(Data);
        }
    }
}
