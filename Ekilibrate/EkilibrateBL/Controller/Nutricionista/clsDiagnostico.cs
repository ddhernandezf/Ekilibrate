using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Autofac;
using Ekilibrate.BL.Queries.Nutricionista;
using Ekilibrate.Model.Entity.Nutricionista;
using Ekilibrate.BL.ad.Nutricionista;

namespace Ekilibrate.BL.Controller.Nutricionista
{
    public class clsDiagnostico : Ekilibrate.BL.ad.Nutricionista.clsDiagnostico
    {
        public clsDiagnostico(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Create(Diagnostico Data)
        {
            var r = await base.GetOne(Data.ParticipanteId, Data.CitaId);
            if (r == null)
                await base.Insert(Data);
            else
                await base.Update(Data);
        }

        

    }




}
