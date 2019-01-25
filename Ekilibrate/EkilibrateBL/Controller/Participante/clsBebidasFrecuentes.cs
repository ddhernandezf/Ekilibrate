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
    public class clsBebidasFrecuentes : Ekilibrate.BL.ad.Participante.clsBebidasFrecuentes
    {
        public clsBebidasFrecuentes(ILifetimeScope lifetimeScope) : base(lifetimeScope) { }

        public async Task Create(clsBebidasFrecuentesBase Data)
        {
            var r = await base.GetBebida(Data.ID_PARTICIPANTE, Data.ID_BEBIDA);
            if (r == null)
             await base.Insert(Data);
        }
    }
}
